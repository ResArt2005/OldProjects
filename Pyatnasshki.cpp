#include <iostream>
using namespace std;


int main()
{
	setlocale(LC_ALL, "Rus");
	int pyat[4][4] =
	{ {1,5,3,6},
	{8,4,2,9},
	{7,10,14,11},
	{12,15,13,0} };
	int a = 1, n;
	for (int i = 0; i < 4; i++)
	{
		for (int j = 0; j < 4; j++)
		{
			cout << pyat[i][j] << "\t";
		}
		cout << endl;
	}

	cout << "It is pyatnashki: 1 - right, 2 - left, 3 - up, 4 - down, 0 - empty place,\nwhat YOU will be moving" << endl;
	cout << "999 - exit" << endl;
	do
	{
		cin >> n;
		switch (n)
		{
		case 1:
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (pyat[i][j] == 0 && pyat[3][3] != 0 && pyat[2][3] != 0
						&& pyat[1][3] != 0 && pyat[0][3] != 0)
					{
						pyat[i][j] = pyat[i][j + 1];
						pyat[i][j + 1] = 0;
					}
				}
			}
			break;
		}
		case 2:
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (pyat[i][j] == 0 && pyat[3][0] != 0 && pyat[2][0] != 0
						&& pyat[1][0] != 0 && pyat[0][0] != 0)
					{
						pyat[i][j] = pyat[i][j - 1];
						pyat[i][j - 1] = 0;
					}
				}
			}
			break;
		}
		case 3:
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (pyat[i][j] == 0 && pyat[0][3] != 0
						&& pyat[0][2] != 0 && pyat[0][1] != 0 && pyat[0][0] != 0)
					{
						pyat[i][j] = pyat[i - 1][j];
						pyat[i - 1][j] = 0;
					}
				}
			}
			break;
		}
		case 4:
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < 4; j++)
				{
					if (pyat[i][j] == 0 && pyat[3][3] != 0
						&& pyat[3][2] != 0 && pyat[3][1] != 0 && pyat[3][0] != 0)
					{
						pyat[i][j] = pyat[i + 1][j];
						pyat[i + 1][j] = 0;
					}
				}
			}
			break;
		}
		case 999: a = -1; break;
		default: cout << "That's way doesn't exist!" << endl;
		}
		cout << endl;

		for (int i = 0; i < 4; i++)
		{
			for (int j = 0; j < 4; j++)
			{
				cout << pyat[i][j] << "\t";
			}
			cout << endl;
		}


	} while (a > 0);

	return 0;
}