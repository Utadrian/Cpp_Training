//: C14:Combined.cpp
// Inheritance & composition

#include <iostream>

using namespace std;

class A {
	int i;
public:
	A(int ii) : i(ii) {}
	~A() {}
	void f() const { cout << i << endl; } /// added cout
};
class B {
	int i;
public:
	B(int ii) : i(ii) {}
	~B() {}
	void f() const {}
};

class C : public B {
	A a;
public:
	C(int ii) : B(ii), a(ii) {}
	~C() {} // Calls ~A() and ~B()
	void f() const { // Redefinition
		a.f();
		B::f();
	}
};

int main() {
	C c(47);
	c.f();
} ///:~