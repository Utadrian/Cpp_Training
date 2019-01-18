//: C14:Composition.cpp
// Reuse code with composition

#include <iostream>
#include "Useful.h"

using namespace std;

class Y {
	int i;
public:
	X x; // Embedded object
	Y() { i = 0; }
	void f(int ii) { i = ii; }
	int g() const { return i; }
};

int main() {
	Y y;
	y.f(47);
	y.x.set(37); // Access the embedded object
	cout << y.x.read(); /// added cout
} ///:~