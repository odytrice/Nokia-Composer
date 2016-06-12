module B2

open A2

type Person = { age:int; otherPerson: A2.Person }
type ThingWrapper = {t: Thing}

let square x = x * x