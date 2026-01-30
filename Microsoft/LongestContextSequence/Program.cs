//
//  Asked by Robert Beardsworth of Microsoft's HIS Team on 2026-01-26 (Monday)
//
string ctx1 = "(a(bc)(defg)h)i)";
string ctx2 = "(a(bc)(q)h)i)";
string ctx3 = "(a(bc)(q)hijk)";

var result1 = LongestSequence(ctx1);
var result2 = LongestSequence(ctx2);
var result3 = LongestSequence(ctx3);

Console.WriteLine(result1);
Console.WriteLine(result2);
Console.WriteLine(result3);

Console.WriteLine();

static string LongestSequence(string context)
{
    var longest_seq = String.Empty;

    var stack = new Stack<string>(16);

    foreach (var ch in context)
    {
        if (ch == '(')
        {
            stack.Push(String.Empty);
        }
        else if (ch == ')')
        {
            var curr = stack.Pop();
            if (curr.Length > longest_seq.Length) longest_seq = curr;
        }
        else
        {
            if (stack.TryPop(out string? curr))
            {
                curr += ch;
                stack.Push(curr);
            }
            else
                stack.Push(ch.ToString());

        }
    }


    return longest_seq;
}