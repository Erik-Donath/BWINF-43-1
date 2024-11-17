import java.util.Scanner;
//Jan Niklas Seipp

public class QuadratischPraktischGrün {
    public static void main(String[]args){
        Scanner scanner = new Scanner(System.in);
        
        //Aussehen/Deko
        System.out.println("Willkommen bei dem Grundstücksrechner");
        System.out.println("-------------------------------------");
        System.out.println(" ");
        System.out.println(" ");

        //Eingabe/in
        System.out.print("Wie viele Interessen gibt es denn: ");
        int interessenten = scanner.nextInt();
        System.out.print("Wie Lang ist das Grundstück denn (in m): ");
        double lang = scanner.nextDouble();
        System.out.print("Wie Breit ist das Grundstück denn (in m): ");
        double breit = scanner.nextDouble();

        //Math/app=area per person/plots= grundstücke
        double flaeche = (lang*breit);
        double app = (flaeche/interessenten);
        double plots = (flaeche/app);

        //Debug
        //System.out.println(" ");
        //System.out.println(" ");
        //System.out.println(" ");
        //System.out.println("Interessenten "+ interessenten);
        //System.out.println("Länge: "+ lang +"meter");
        //System.out.println("Breite: "+ breit +"meter");
        //System.out.println("Fläche: "+ flaeche +" quadratmeter");
        //System.out.println("Fläche pro Person: "+ app +" quadratmeter");
        //System.out.println("Flächen: "+ plots);
        //System.out.println(" ");
        //System.out.println(" ");

        //Aussehen/Deko
        System.out.println(" ");
        System.out.println(" ");
        System.out.println("-------------------------------------");

        //Ausgabe
        System.out.println("Mit den von Ihnen angebenen Informationen ("+lang+"m Länge und "+breit+"m Breite) also einer gesamt Fläche von "+flaeche+" quadratmetern,");
        System.out.println("kommt es auf "+plots+" Grundstücke für "+interessenten+" Interessenten die eine Fläche von "+app+" quadratmetern pro Person bekommen.");
        System.out.println(" ");

        //Aussehen/Deko
        System.out.println(" ");
        System.out.println(" ");

        //Scanner close
        scanner.close();
    }
}