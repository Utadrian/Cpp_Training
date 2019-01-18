//: C13:NewHandler.cpp
// Changing the new-handler
#include <iostream>
#include <cstdlib>
#include <new>
using namespace std;

int count1 = 0;

void out_of_memory() {
	cerr << "memory exhausted after " << count1
		<< " allocations!" << endl;
	exit(1);
}

int main() {
	set_new_handler(out_of_memory);
	while (1) {
		count1++;
		new int[1000]; // Exhausts memory
	}
} ///:~