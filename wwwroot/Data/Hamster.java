package animals.rodents;

import animals.Animal;

public class Hamster extends Rodent {

    public Hamster(String name, int age) {
        super(name, age); // call the constructor of the superclass
    }

    public Hamster(String name) {
        super(name); // call the constructor of the superclass
    }

    // overridden method from Rodent
    @Override
    public void chill(int duration) { // chill method
        System.out.println("The Hamster " + getName() + " chills under a cold AC for " + duration + " seconds.");
    }

    @Override
    public void makeSound(int duration) { // makeSound method
        squeak(duration);
    }

    // new method for this class
    public void squeak(int duration) { // squeak method
        System.out.println("The Hamster " + getName() + " squeaks for " + duration + " seconds.");
    }
}
