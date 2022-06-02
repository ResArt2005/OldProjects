#include <iostream>
using namespace std;


int check(int mass[3][3])
{
	int a = 1;
	if ((mass[0][0] + mass[0][1] + mass[0][2] == 3) ||
		(mass[1][0] + mass[1][1] + mass[1][2] == 3) ||
		(mass[2][0] + mass[2][1] + mass[2][2] == 3) || 

		(mass[0][0] + mass[1][0] + mass[2][0] == 3) ||
		(mass[0][1] + mass[1][1] + mass[2][1] == 3) ||
		(mass[0][2] + mass[1][2] + mass[2][2] == 1) || 

		(mass[0][0] + mass[1][1] + mass[2][2] == 3) ||
		(mass[0][2] + mass[1][1] + mass[2][0] == 3))
	{
		cout << "1 player won!" << endl;
		a = -1;
	}

	if ((mass[0][0] + mass[0][1] + mass[0][2] == 6) ||
		(mass[1][0] + mass[1][1] + mass[1][2] == 6) ||
		(mass[2][0] + mass[2][1] + mass[2][2] == 6) || 

		(mass[0][0] + mass[1][0] + mass[2][0] == 6) ||
		(mass[0][1] + mass[1][1] + mass[2][1] == 6) ||
		(mass[0][2] + mass[1][2] + mass[2][2] == 6) || 

		(mass[0][0] + mass[1][1] + mass[2][2] == 6) || 
		(mass[2][0] + mass[1][1] + mass[0][2] == 6))
	{
		cout << "2 player won!" << endl;
		a = -1;
	}
	return a;
}



int main()
{
	setlocale(LC_ALL, "Rus");
	int x; int n; int a = 1;
	string zone[3][3] = { {" 1 "," 2 "," 3 "}, {" 4 "," 5 "," 6 "}, {" 7 "," 8 "," 9 "}, };
	int mass[3][3];
	for (int i = 0; i < 3; i++)
	{
		for (int j = 0; j < 3; j++)
		{
			cout << zone[i][j];
		}
		cout << endl;
	}
	cout << "1 player - X" << endl;
	cout << "2 player - 0" << endl;
	cout << "In order enter X or 0" << endl;
	do
	{
		cout << "1 player" << endl;
		cin >> x;

		switch (x)
		{
		case 1:
		{
			mass[0][0] = 1;
			zone[0][0] = " X "; break;
		}
		case 2:
		{
			mass[0][1] = 1;
			zone[0][1] = " X "; break;
		}
		case 3:
		{
			mass[0][2] = 1;
			zone[0][2] = " X "; break;
		}
		case 4:
		{
			mass[1][0] = 1;
			zone[1][0] = " X "; break;
		}
		case 5:
		{
			mass[1][1] = 1;
			zone[1][1] = " X "; break;
		}
		case 6:
		{
			mass[1][2] = 1;
			zone[1][2] = " X "; break;
		}
		case 7:
		{
			mass[2][0] = 1;
			zone[2][0] = " X "; break;
		}
		case 8:
		{
			mass[2][1] = 1;
			zone[2][1] = " X "; break;
		}
		case 9:
		{
			mass[2][2] = 1;
			zone[2][2] = " X "; break;
		}

		default: cout << "Wrong dijit, it means you passed your yurn!" << endl;
		}

		a = check(mass);
		if (a == -1)
			break;
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				cout << zone[i][j];
			}
			cout << endl;
		}

		cout << "2 player" << endl;
		cin >> n;

		switch (n)
		{
		case 1:
		{
			mass[0][0] = 2;
			zone[0][0] = " 0 "; break;
		}
		case 2:
		{
			mass[0][1] = 2;
			zone[0][1] = " 0 "; break;
		}
		case 3:
		{
			mass[0][2] = 2;
			zone[0][2] = " 0 "; break;
		}
		case 4:
		{
			mass[1][0] = 2;
			zone[1][0] = " 0 "; break;
		}
		case 5:
		{
			mass[1][1] = 2;
			zone[1][1] = " 0 "; break;
		}
		case 6:
		{
			mass[1][2] = 2;
			zone[1][2] = " 0 "; break;
		}
		case 7:
		{
			mass[2][0] = 2;
			zone[2][0] = " 0 "; break;
		}
		case 8:
		{
			mass[2][1] = 2;
			zone[2][1] = " 0 "; break;
		}
		case 9:
		{
			mass[2][2] = 2;
			zone[2][2] = " 0 "; break;
		}

		default: cout << "Wrong dijit, it means you passed your yurn!" << endl;
		}
		for (int i = 0; i < 3; i++)
		{
			for (int j = 0; j < 3; j++)
			{
				cout << zone[i][j];
			}
			cout << endl;
		}
		a = check(mass);
		if (a == -1)
			break;
	} while (a > 0);

	return 0;
}