#include <iostream>
#include <fstream>

using namespace std;

ifstream in("date.in");
ofstream out("date.out");

int main()
{
	int n;
	in >> n;
	while (n)
	{
		int a[101][101] = { 0 };
		for (int i = 1; i <= n; i++)
		{
			for (int j = i; j <= n; j++)
			{
				a[i][j] = j;
			}
		}
		int i = 0;
		int nr = 0;
		i = (n % 2 == 1) ? 1 : 2;
		for (i; i <= n; i+=2)
		{
			if (nr)
			{
				a[i][i - 1] = nr;
				nr = 0;
			}
			else
			{
				nr = a[i][i + 1];
				a[i][i + 1] = a[i][i];
				a[i][i] = 0;
			}
		}
		if ((n % 2 == 0 && n % 4 == 2) || (n % 2 == 1 && n % 4 == 1))
		{
			out << "0" << endl << endl;
		}
		else
		{
			out << n << endl;
			for (int i = 1; i <= n; i++)
			{
				for (int j = 1; j <= n; j++)
				{
					if (a[i][j])
					{
						if (a[i][j] < 10)
							out << " " << a[i][j] << " ";
						else
							out << a[i][j] << " ";
					}
				}
				out << endl;
			}
			out << endl;
		}
		in >> n;
	}
	return 0;
}
