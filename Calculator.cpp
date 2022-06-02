#include <iostream>
#include <stack>
#include <cmath>

using namespace std;

struct Leksema
{
	char type;
	double value;
};

bool Maths(stack <Leksema>& Stack_n, stack <Leksema>& Stack_o, Leksema& item)
{
	double a, b, c;
	a = Stack_n.top().value;
	Stack_n.pop();
	switch (Stack_o.top().type)
	{
	case '+':
	{
		b = Stack_n.top().value;
		Stack_n.pop();
		c = a + b;
		item.type = '0';
		item.value = c;
		Stack_n.push(item);
		Stack_o.pop();
	}
	break;
	case '-':
	{
		b = Stack_n.top().value;
		Stack_n.pop();
		c = b - a;
		item.type = '0';
		item.value = c;
		Stack_n.push(item);
		Stack_o.pop();
	}
	break;
	case '^':
	{
		b = Stack_n.top().value;
		Stack_n.pop();
		c = pow(b, a);
		item.type = '0';
		item.value = c;
		Stack_n.push(item);
		Stack_o.pop();
	}
	break;
	case '*':
	{
		b = Stack_n.top().value;
		Stack_n.pop();
		c = a * b;
		item.type = '0';
		item.value = c;
		Stack_n.push(item);
		Stack_o.pop();
	}
	break;
	case '/':
	{
		b = Stack_n.top().value;
		if (a == 0)
		{
			cerr << "\nError!\n";
			return false;
		}
		else
		{
			Stack_n.pop();
			c = (b / a);
			item.type = '0';
			item.value = c;
			Stack_n.push(item);
			Stack_o.pop();
		}
	}
	break;
	default:
	{
		cerr << "\nError!\n";
		return false;
	}
	break;
	}
	return true;
}

int getRang(char ch)
{
	if (ch == '^')
	{
		return 3;
	}
	if (ch == '+' || ch == '-')
	{
		return 1;
	}
	if (ch == '*' || ch == '/')
	{
		return 2;
	}
	else
	{
		return 0;
	}
}

int main()
{
	setlocale(LC_ALL, "rus");
	cout << "Enter an expression: ";
	char ch;
	double value;
	bool flag = 1;
	stack <Leksema> Stack_n; 
	stack <Leksema> Stack_o;
	Leksema item;
	while (1)
	{
		ch = cin.peek();
		if (ch == '\n')
		{
			break;
		}
		if (ch == ' ')
		{
			cin.ignore();
			continue;
		}
		if (ch >= '0' && ch <= '9' || ch == '-' && flag == 1)
		{
			cin >> value;
			item.type = '0';
			item.value = value;
			Stack_n.push(item);
			flag = 0;
			continue;
		}
		if (ch == '+' || ch == '-' && flag == 0 || ch == '*' || ch == '/' || ch == '^')
		{
			if (Stack_o.size() == 0)
			{
				item.type = ch;
				item.value = 0;
				Stack_o.push(item);
				cin.ignore();
				continue;
			}
			if (Stack_o.size() != 0 && getRang(ch) > getRang(Stack_o.top().type))
			{
				item.type = ch;
				item.value = 0;
				Stack_o.push(item);
				cin.ignore();
				continue;
			}
			if (Stack_o.size() != 0 && getRang(ch) <= getRang(Stack_o.top().type))
			{
				if (Maths(Stack_n, Stack_o, item) == false)
				{
					system("pause");
					return 0;
				}
				continue;
			}
		}
		if (ch == '(')
		{
			item.type = ch;
			item.value = 0;
			Stack_o.push(item);
			cin.ignore();
			continue;
		}
		if (ch == ')')
		{
			while (Stack_o.top().type != '(')
			{
				if (Maths(Stack_n, Stack_o, item) == false)
				{
					system("pause");
					return 0;
				}
				else
				{
					continue;
				}
			}
			Stack_o.pop();
			cin.ignore();
			continue;
		}
		else
		{
			cout << "\nError!\n";
			system("pause");
			return 0;
		}
	}
	while (Stack_o.size() != 0)
	{
		if (Maths(Stack_n, Stack_o, item) == false)
		{
			system("pause");
			return 0;
		}
		else
		{
			continue;
		}
	}
	cout << "Answer: " << Stack_n.top().value << "\n";
	return 0;
}