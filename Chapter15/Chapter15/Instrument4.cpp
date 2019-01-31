//: C15:Instrument4.cpp
// Extensibility in OOP

#include <iostream>
#include <string>

using namespace std;

enum note { middleC, Csharp, Cflat }; // Etc.

class Instrument {
public:
	virtual void play(note) const {
		cout << "Instrument::play" << endl;
	}
	virtual string what() const {
		return "Instrument";
	}
	// Assume this will modify the object:
	virtual void adjust(int) {}
};
class Wind : public Instrument {
public:
	void play(note) const {
		cout << "Wind::play" << endl;
	}
	string what() const { return "Wind"; }
	void adjust(int) {}
};

class Percussion : public Instrument {
public:
	void play(note) const {
		cout << "Percussion::play" << endl;
	}
	string what() const { return "Percussion"; }
	void adjust(int) {}
};

class Stringed : public Instrument {
public:
	void play(note) const {
		cout << "Stringed::play" << endl;
	}
	string what() const { return "Stringed"; }
	void adjust(int) {}
};

class Brass : public Wind {
public:
	void play(note) const {
		cout << "Brass::play" << endl;
	}
	string what() const { return "Brass"; }
};

class Woodwind : public Wind {
public:
	void play(note) const {
		cout << "Woodwind::play" << endl;
	}
	string what() const { return "Woodwind"; }
};

// Identical function from before:
void tune(Instrument& i) {
	// ...
	i.play(middleC);
}

// New function:
void f(Instrument& i) { i.adjust(1); }
// Upcasting during array initialization:

Instrument* A[] = {
new Wind,
new Percussion,
new Stringed,
new Brass,
};

int main() {
	Wind flute;
	Percussion drum;
	Stringed violin;
	Brass flugelhorn;
	Woodwind recorder;
	tune(flute);
	tune(drum);
	tune(violin);
	tune(flugelhorn);
	tune(recorder);
	f(flugelhorn);
} ///:~