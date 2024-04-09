namespace SubstitutionCipher
{
    class Cipher
    {
        public const string NormalAlphabet = "abcdefghijklmnopqrstuvwxyz";
        public string CodedAlphabet;

        public Cipher(string Coded)
        {
            CodedAlphabet = Coded;
        }

        public string Encode(string Input)
        {
            string EndResult = "";

            foreach (char EachCharacter in Input)
            {
                //find the index of each character in the normal alphabet and set it to a value
                int CharIndex = NormalAlphabet.IndexOf(EachCharacter);
                //find the index at normalcharindex in codedalphabet
                char OutputChar = CodedAlphabet[CharIndex];
                EndResult += OutputChar;
            }

            return EndResult;
        }

        public string Decode(string Input)
        {
            string EndResult = "";

            foreach (char EachCharacter in Input)
            {
                int CharIndex = CodedAlphabet.IndexOf(EachCharacter);
                char OutputChar = NormalAlphabet[CharIndex];
                EndResult += OutputChar;

            }

            return EndResult;
        }
    }
}