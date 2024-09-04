// Change this if you want to change the order of character weighting
// You also can just add new characters to have them counted as well
const JUMPING_DISTANCES: &str = "abcdefghijklmnopqrstuvwxyzäöüß";

fn main() {
    // Vorläufig, muss noch überprüft werden
    let text = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.";

    let bela_result = jump(text, 0);
    let amira_result = jump(text, 1);

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
