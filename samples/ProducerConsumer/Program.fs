// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp

open System
open System.Threading.Tasks
open FSharp.Channels
open System.Threading.Channels
open FSharp.Control.Tasks

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

type Msg = { Value: int }

let producer(writer: ChannelWriter<Msg>) =
    task {
        for i = 0 to 20 do
            let! _ = writer |> Channel.writeAsync({ Value = i })
            printf "dads"
        writer.Complete()
        return ()
    }

        
[<EntryPoint>]
let main argv =
    let struct (reader, writer) = Channel.unbounded(None)
    let producerT = producer(writer)
    
    Task.WaitAll(producerT)
    0 // return an integer exit code