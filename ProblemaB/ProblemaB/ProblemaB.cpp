#include <iostream>
#include <string>

using namespace std;

int numberOfABCD = 0;

bool checkIfTrue(char arr[], int current)
{
	if (current >= 0)
	{
		if (strchr("abcd", arr[current]))
			numberOfABCD++;

		// for cases na, nb, nc, nd
		if (numberOfABCD == 1 && arr[current - 1] == 'n' && (current - 1 == 0))
			return true;

		//for xts, yts and zts forms
		if (numberOfABCD == 0 && current == 0)
			return true;

		else if (numberOfABCD == 2)
		{
			if (!strchr("xyzn", arr[current - 1]))
				return false;
			else if (arr[current - 1] == 'n')
				return checkIfTrue(arr, current - 1);
			else
			{
				numberOfABCD = 0;
				if (current - 2 < 0)
					return true;
				else return checkIfTrue(arr, current - 2);
			}
		}

		else if (numberOfABCD > 2)
			return false;
	}
	else return false;
	return checkIfTrue(arr, current - 1);
}

bool isTrue(char arr[])
{
	if (strchr("abcd", arr[strlen(arr) - 1]) && strchr("xyzt", arr[strlen(arr) - 2]))
		return false;
	else if (checkIfTrue(arr, strlen(arr) - 1) ||
		strlen(arr) == 1 && strchr("abcd", arr[strlen(arr) - 1]))
	{
		numberOfABCD = 0;
		return true;
	}
	else
	{
		numberOfABCD = 0;
		return false;
	}
}

int main()
{
	char arr[1000] = {"xab"};
	if (isTrue(arr))
		cout << "DA" << endl;
	else cout << "NU" << endl;

	char arr1[1000] = { 'a' };
	if (isTrue(arr1))
		cout << "DA" << endl;
	else cout << "NU" << endl;

	char arr2[1000] = { "na" };
	if (isTrue(arr2))
		cout << "DA" << endl;
	else cout << "NU" << endl;

	char arr3[1000] = { "nnnnnnnnna" };
	if (isTrue(arr3))
		cout << "DA" << endl;
	else cout << "NU" << endl;

	char arr4[1000] = { "xnnnnnnnnna" };
	if (isTrue(arr4))
		cout << "DA" << endl;
	else cout << "NU" << endl;

	char arr5[1000] = { "xnnnnbnnnnnnnnna" };
	if (isTrue(arr5))
		cout << "DA" << endl;
	else cout << "NU" << endl;
	return 0;
}
