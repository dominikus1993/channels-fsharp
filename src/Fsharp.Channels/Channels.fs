namespace Fsharp

module Channel =
    open System.Threading.Channels

    let unbounded<'a>(opt : Option<_>) =
        let options = defaultArg opt null
        let ch = Channel.CreateUnbounded<'a>(options)
        struct (ch.Reader, ch.Writer)
