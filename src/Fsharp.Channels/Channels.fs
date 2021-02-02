namespace FSharp.Channels

open System.Runtime.CompilerServices
open System.Threading.Tasks
open FSharp.Control.Tasks

module Channel =
    open System.Threading.Channels

    let unbounded<'a>(opt : Option<_>) =
        let options = defaultArg opt null
        let ch = Channel.CreateUnbounded<'a>(options)
        struct (ch.Reader, ch.Writer)
    
    let write(msg) (writer: ChannelWriter<_>)  =
        writer.TryWrite(msg) |> ignore
        writer
      
    let writeAsync(msg) (writer: ChannelWriter<_>)  =
        vtask {
            writer.WriteAsync(msg) |> ignore
            return writer;
        }
        