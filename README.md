# Polly

Polly is a Discord bot used for polling messages, built on .Net Core 2.1 and written in C#.

> This is a work in progress, lots of breaking changes might occur until an official release. This project is not ready for public use yet.

## Build

### Requirements

- .Net Core 2.1 SKD

### Configuration

Under the `Polly\Properties` folder, you will find the `settings.json` file containing Polly's Bot Token and the channel it will be working in.

The `settings.json` file looks like this:

```json
{
  "Bot": {
    "Name": "Polly",
    "Token": "YourTokenHere",
    "PollChannel": "TextChannelIdHere"
  }
}
```

It's not ment to be used on more than one server (at least for now, might change it later on down the road), so the way it's supposed to work is the following:

- Have a dedicated **text** channel on Discord where all messages sent by users can be voted on, because the bot will take those messages and add 👍🏻, 👎🏻 and 🤷 reactions to them.
- You will have to set the ID of thet dedicated text channel in the `settings.json` file, under `PollChannel: ""`

Navigate to the solution folder and execute this command using your prefered terminal:

```powershell
> dotnet build [-c Release]
```

> Add `-r win-x64` at the end to produce and `Polly.exe` file alongside the generated `Polly.dll`

Then to run, use:

```powershell
> dotnet run --project .\Polly\Polly.csproj
```

## License

<pre>
MIT License

Copyright (c) 2018 TheKrystalShip

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
</pre>
