

int[] array = { 0,1, 2,2,2, 3, 4, 5, 6, 7 };

int k = 2;
int leftOccuranceIndex(int[] nums)
{

    int left = 0, right = nums.Length - 1;

    while(right-left > 1)
    {
        int mid = left + (right - left) / 2;

        if (nums[mid] >= k)
        {
            right = mid;
        }
        else
            left = mid;
    }

    if (nums[left] == k)
    {
        return left;
    }
    else
        return right;
}

int rightOccuranceIndex(int[] nums)
{

    int left = 0, right = nums.Length - 1;

    while (right - left > 1)
    {
        int mid = left + (right - left) / 2;

        if (nums[mid] <= k)
        {
            left = mid;
        }
        else
            right = mid;
    }

    if (nums[left] == k)
    {
        return left;
    }
    else
        return right;
}

int result = leftOccuranceIndex(array);
int result1 = rightOccuranceIndex(array);
Console.WriteLine(result);
Console.WriteLine(result1);