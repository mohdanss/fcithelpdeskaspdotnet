package animals.rodents;

import animals.Animal;

public abstract class Rodent extends Animal{
        
        public Rodent(String name, int age) { // constructor
            super(name, age);
        }
        
        public Rodent(String name) { // constructor
            super(name);
        }
        
        public abstract void chill(int duration);
        
        @Override
        public void print() { // print method
            super.print();
            System.out.println("    Rodent " + getName() + " is cool.");
        }
        
        // overridden emthod
        @Override
        public int getNumberOfLegs() { // getNumberOfLegs method
            return 4;
        }
}


