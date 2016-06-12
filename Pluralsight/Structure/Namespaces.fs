namespace Name.A

type Person = {name:string}
type Thing = {a:int}

namespace Name.B

type Person = {age:int; otherPerson: Name.A.Person}

open Name.A
type ThingWrapper = {t: Thing}

