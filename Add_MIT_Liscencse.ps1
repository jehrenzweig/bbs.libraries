$invocation = (Get-Variable MyInvocation).Value
$directorypath = Split-Path $invocation.MyCommand.Path

param($target = $directorypath, $companyname = "Betabyte Software")

#[System.Globalization.CultureInfo] $ci = [System.Globalization.CultureInfo]::GetCultureInfo("pt-BR")
[System.Globalization.CultureInfo] $ci = [System.Globalization.CultureInfo]::GetCurrentCulture

# Full date pattern with a given CultureInfo
# Look here for available String date patterns: http://www.csharp-examples.net/string-format-datetime/
$date = (Get-Date).ToString("F", $ci);

# Header template
$header = "//-----------------------------------------------------------------------
//    MIT License
//
//    Copyright (c) {2} Betabyte Software
//
//    Permission is hereby granted, free of charge, to any person obtaining a copy
//    of this software and associated documentation files (the ""Software""), to deal
//    in the Software without restriction, including without limitation the rights
//    to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//    copies of the Software, and to permit persons to whom the Software is
//    furnished to do so, subject to the following conditions:
//
//    The above copyright notice and this permission notice shall be included in all
//    copies or substantial portions of the Software.

//    THE SOFTWARE IS PROVIDED ""AS IS"", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//    IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//    FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//    AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//    LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//    OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//    SOFTWARE.
//-----------------------------------------------------------------------`r`n"

function Write-Header ($file)
{
  # Get the file content as as Array object that contains the file lines
  $content = Get-Content $file
  # Getting the content as a String
  $contentAsString = $content | Out-String

  <# If content starts with // then the file has a copyright notice already
  Let's Skip the first 27 lines of the copyright notice template... #>
  if(!$contentAsString.StartsWith("//"))
  {
    # Splitting the file path and getting the leaf/last part, that is, the file name

    $filename = Split-Path -Leaf $file

    # $fileheader is assigned the value of $header with dynamic values passed as parameters after -f

    $fileheader = $header -f $filename, $companyname, $date

    # Writing the header to the file
    Set-Content $file $fileheader -encoding UTF8

    # Append the content to the file
    Add-Content $file $content
  }
}

#Filter files getting only .cs ones and exclude specific file extensions
Get-ChildItem $target -Filter *.cs -Exclude AssemblyInfo.cs,*.Designer.cs,T4MVC.cs,*.generated.cs,*.ModelUnbinder.cs -Recurse | % `
{
  <# For each file on the $target directory that matches the filter,
  let's call the Write-Header function defined above passing the file as
  parameter #>

  Write-Header $_.PSPath.Split(":", 3)[2]
}


Write-Host "Press any key to continue ..."

$x = $host.UI.RawUI.ReadKey("NoEcho,IncludeKeyDown")
