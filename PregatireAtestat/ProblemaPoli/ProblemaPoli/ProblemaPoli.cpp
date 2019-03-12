// ProblemaPoli.cpp : This file contains the 'main' function. Program execution begins and ends there.
//
#include <iostream>
#include <fstream>
#include <string>
#include <map>

using namespace std;

ifstream in("date.in");
ofstream out("date.out");

class Frequency
{
public:
	int left;
	int right;
	bool hasTranslation;

	Frequency()
	{
		left = 0;
		right = 0;
		hasTranslation = false;
	};
};

map<string, Frequency> foreignLFreq;
map<string, Frequency> knownLFreq;

int main()
{
	int n;
	in >> n;
	int nrOfWords = 0;
	for (int i = 1; i <= n; i++)
	{
		string a;
		in >> a;
		if (foreignLFreq[a].left == 0 && foreignLFreq[a].right == 0)
		{
			nrOfWords++;
		}
		foreignLFreq[a].left++;
		in >> a;
		foreignLFreq[a].right++;
	}
	for (int i = 1; i <= n; i++)
	{
		string b;
		in >> b;
		knownLFreq[b].left++;
		in >> b;
		knownLFreq[b].right++;
	}

	return 0;
}

