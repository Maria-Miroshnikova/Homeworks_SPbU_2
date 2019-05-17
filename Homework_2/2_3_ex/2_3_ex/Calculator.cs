using System;

namespace StackNameSpace
{
    class Calculator
    {
	//Stack* stack = createStack();

	for (size_t i = 0; i < data.length(); ++i)
	{	
		if (data[i] == ' ')
		{
			++i;
		}

		if (data[i] == '*')
		{	
			push(stack, pop(stack) * pop(stack));
		}
		else if (data[i] == '/')
		{
			int firstValue = pop(stack);
			int secondValue = pop(stack);
			push(stack, secondValue / firstValue);
		}
		else if (data[i] == '+')
		{
			push(stack, pop(stack) + pop(stack));
		}
		else if (data[i] == '-')
		{
			int firsValue = pop(stack);
			int secondValue = pop(stack);
			push(stack, secondValue - firsValue);
		}

		else
		{
			push(stack, data[i] - '0');
		}
	}

	int expressionValue = pop(stack);
	deleteStack(stack);
	return expressionValue;
}
}
