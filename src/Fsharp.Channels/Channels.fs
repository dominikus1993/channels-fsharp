namespace Fsharp

module Channels =
    open System.Threading.Channels

    let unbounded (opt : Option<_>) =
        let options = defaultArg opt null
        Channel.CreateUnbounded(options)
