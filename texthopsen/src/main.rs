#![feature(let_chains)]

use colored::{Color, Colorize};
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

    println!(
        "{}\n\n",
        create_colored_text(text, bela_result.1, amira_result.1)
    );

    if bela_result.0 < amira_result.0 {
        println!("{} won!", "Bela".red());
    } else {
        println!("{} won!", "Amira".blue());
    }
}

fn jump(text: &str, start_index: usize) -> (usize, Vec<usize>) {
    let text = text.to_lowercase();

    let mut jumps = 0;
    let mut letter_indices = Vec::new();

    let mut jump_index = start_index;
    let mut current_index = start_index;

    for (letter_index, char) in text.chars().skip(start_index).enumerate() {
        let new_jump_distance = JUMPING_DISTANCES.find(char);

        if new_jump_distance.is_none() {
            continue;
        }

        if current_index == jump_index {
            letter_indices.push(letter_index + start_index);

            jump_index += new_jump_distance.unwrap() + 1;
            jumps += 1;
        }

        current_index += 1;
    }

    (jumps, letter_indices)
}

fn create_colored_text(
    text: String,
    mut bela_indices: Vec<usize>,
    mut amira_indices: Vec<usize>,
) -> String {
    let mut colored_text = String::new();
    for (index, char) in text.chars().enumerate() {
        if let Some(letter_index) = bela_indices.first()
            && index == *letter_index
        {
            // check whether both are on the same letter
            if let Some(letter_index) = amira_indices.first()
                && index == *letter_index
            {
                amira_indices.remove(0);
                colored_text.push_str(char.to_string().color(Color::Magenta).to_string().as_str());
            } else {
                colored_text.push_str(char.to_string().color(Color::Red).to_string().as_str());
            }

            bela_indices.remove(0);
        } else if let Some(letter_index) = amira_indices.first()
            && index == *letter_index
        {
            colored_text.push_str(char.to_string().color(Color::Blue).to_string().as_str());

            amira_indices.remove(0);
        } else {
            colored_text.push(char);
        }
    }

    colored_text
}
