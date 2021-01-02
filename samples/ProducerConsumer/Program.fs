// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open FSharp.Channels
open System.Threading.Channels

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

type Msg = { Value: int }

let producer(writer: ChannelWriter<Msg>) =
    for i = 0 to 20 do
        writer |> Channel.write({ Value = i }) |> ignore
        
[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    0 // return an integer exit code