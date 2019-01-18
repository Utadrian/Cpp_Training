//: C14:Composition2.cpp
// Private embedded objects

#include "Useful.h"
#include <iostream>

using namespace std;

class Y {
	int i;
	X x; // Embedded object
public:
	Y() { i = 0; }
	void f(int ii) { i = ii; x.set(ii); }
	int g() const { return i * x.read(); }
	int read() { return x.read(); }
	void permute() { x.permute(); }
};

int main() {
	Y y;
	y.f(47);
	y.permute();
	cout << y.read(); /// added cout and Y::read() function
} ///:~