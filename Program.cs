
// 引数を取得
using CombinationGenerator;

var @params = Environment.GetCommandLineArgs();
// 引数が2つ以上ある場合はエラー
if (@params.Length != 2)
{
  Console.WriteLine("Usage: Program.exe <csv_path>");
  return;
}

var csvPath = @params[1];

var result = Logic.GenerateCombination(csvPath);

// 結果をファイルに出力
File.WriteAllText($"result-{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv", result);
