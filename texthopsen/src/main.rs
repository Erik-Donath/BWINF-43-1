use std::{env::args, fs::read_to_string, process::exit};

// Change this if you want to change the order of character weighting
// You also can just add new characters to have them counted as well
const JUMPING_DISTANCES: &str = "abcdefghijklmnopqrstuvwxyzäöüß";

fn main() {
    let path = match args().nth(1) {
        Some(path) => path,
        None => {
            eprintln!("You have to supply one argument with the path of the file of text.\n\nExample:\n./texthopsen ./relative/path/to/file");
            exit(1);
        }
    };

    let text = match read_to_string(path) {
        Ok(text) => text,
        Err(_) => {
            eprintln!("Couldn't load file.\nAre you sure that the path is correct?");
            exit(1)
        }
    };

    let bela_result = jump(&text, 0);
    let amira_result = jump(&text, 1);

    if bela_result < amira_result {
        println!("Bela won!");
    } else {
        println!("Amira won!");
    }
}

fn jump(text: &str, mut index: usize) -> usize {
    let mut text = text.to_lowercase();
    text = text
        .chars()
        .filter(|char| JUMPING_DISTANCES.contains(*char))
        .collect();

    let mut jumps = 0;

    while let Some(char) = text.chars().nth(index) {
        jumps += 1;

        let jumping_distance = JUMPING_DISTANCES.find(char).unwrap();
        index += jumping_distance + 1;
    }

    jumps
}
