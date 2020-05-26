using System;

namespace AdventOfCode.Day2
{
	class Init
	{
		static void Main()
		{
			IntCodeComputer computer = 
				new IntCodeComputer (
					IntCodeComputer.ParseIntCode("input.txt"));

			Console.WriteLine ("********************");
			Console.WriteLine ("* Buffer Before eval");
			Console.WriteLine ("********************");
			computer.PrintBuffer();

			computer.ProcessCode();

			Console.WriteLine ("\n*******************");
			Console.WriteLine ("* Buffer After Eval");
			Console.WriteLine ("*******************");
			computer.PrintBuffer();
			Console.WriteLine();

		}
	}

	class IntCodeComputer
	{

		private enum IntCode : uint {
			FIN  = 99,
			ADD  = 1,
			MUL  = 2
		};

		private struct opCode
		{
			public opCode (IntCode code, 
				int operandAddr_0, int operandAddr_1, int outputAddr)
			{
				Code    		= code;
				OperandAddr_0   = operandAddr_0;
				OperandAddr_1   = operandAddr_1;
				OutputAddr  	= outputAddr;
			}

			public IntCode Pos_0 {get; set;}
			public int Pos_1 	 {get; set;}
			public int Pos_2 	 {get; set;}
			public int Pos_3 	 {get; set;}

			public override string ToString() 
				=> $"[{Pos_0}]\t[{Pos_1}]\t[{Pos_2}]\t[{Pos_3}]"
		}

		private class Buffer() {
			public opCode Register_0 {get; set;}
			public opCode Register_1 {get; set;}

			public Buffer () {}

			public void FlushRegisters() 
			{
				Operand_0 = null;
				Operand_1 = null;
			}
		}


		public opCode[] Program {get; private set;}
		public int LineIndex {get; private set;} = 0;
		private Buffer buffer {get; set;} = new Buffer();

		public IntCodeComputer (opCode[] program)
		{
			Program = program;
		}

		private IntCode ReadNext()
		{
			if (Program.Length < Index ) return IntCode.FIN;

			LineIndex++;
			return (OpCode)IntCode[Index - 4];
		}

		private bool EvalCode(OpCode code)
		{
			switch (code) {
				case OpCode.FIN:
					return false;
				case OpCode.ADD:
					IntCode[Index + 3] =
						IntCode[IntCode[Index + 1]]
						+
						IntCode[IntCode[Index + 2]];
					return true;
				case OpCode.MUL:
					IntCode[Index + 3] =
						IntCode[IntCode[Index + 1]]
						*
						IntCode[IntCode[Index + 2]];
						return true;
				default: return false;
			}
		}

		public RunProgram()
		{
			foreach (opCode line in Program) {
				//Load line into buffer Register_0
				buffer.Register_0 = line;

				//Retrieve Next Line
				buffer.Register_1 = 
					Program[TranslateLinearAddress(Register_0.)]


			}
		}

		public void PrintBuffer()
		{
			for (int i=0; i < IntCode.Length; i++) {
				if ( i % 4  == 0 ) Console.WriteLine();
				Console.Write ($"[{IntCode[i]}] ");
			}

		}

		public static opCode[] ParseIntCode(String path)
		{
			String[] parsedProgram = 
				System.IO.File.ReadAllText (@path).Split(',');

			opCode[] program = new opCode[parsedCode.Length / 4]; 

			int index = 0;
			for (int line=0; line < parsedCode.Length / 4; line++)  {
				program[line].Code = 
					(IntCode)Convert.ToInt32 (parsedProgram[index]);
				program[line].OperandAddr_0 = 
					Convert.ToInt32 (parsedProgram[index + 1]);
				program[line].OperandAddr_1 = 
					Convert.ToInt32 (parsedProgram[index + 2]);
				program[line].OutputAddr = 
					Convert.ToInt32 (parsedProgram[index + 3]);

				index += 4;
			}

			return program;
		}
	}
}