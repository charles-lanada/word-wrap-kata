using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Wordwrap
{
    public class Wrapper
    {
        private int lineBreak;

        public string Wrap(string input, int lineBreak)
        {
            this.lineBreak = lineBreak;
            return ActualWrap(input);
        }

        private string ActualWrap(string input)
        {
            if (input.Length <= lineBreak)
            {
                return input;
            }

            var space = input[..lineBreak].LastIndexOf(' ');
            var hasSpaceAfterWordBoundary = space != -1;
            if(hasSpaceAfterWordBoundary)
            {
                return BreakLine(input, space, 1);
            }

            if (HasSpaceOnWordBoundary(input))
            {
                return BreakLine(input, lineBreak, 1);
            }

            return BreakLine(input, lineBreak, 0);
        }

        private bool HasSpaceOnWordBoundary(string input)
        {
            return input[lineBreak] == ' ';
        }

        private string BreakLine(string input, int position, int gap)
        {
            return $"{input[..position]}\n" + ActualWrap(input[(position + gap)..]);
        }
    }
}
