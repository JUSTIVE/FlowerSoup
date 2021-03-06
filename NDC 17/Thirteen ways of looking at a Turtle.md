# Thirteen ways of looking at a Turtle
NDC London 2017 Scott Wlaschin
https://www.youtube.com/watch?v=AG3KuqDbmhM&t=1804s

문제를 풂에 있어서 많은 접근 방법(taste of many different approaches)들이 있다.
- partial application
- actor model
- error handling
- event sourcing
- dependency injection
- state monad
- interpreter
- capabilities
  
## Turtle graphics in action

네모 안에 거북이가 있다고 치고, 이 거북이가 움직이면서 선을 그릴 것입니다. 사용될 API는 다음과 같습니다.
|API|설명|
|---|---|
|Move aDistance| 현재 위치에서 일정 거리를 움직입니다.|
|Turn anAngle|주어진 각도만큼 시계 혹은 반시계 방향으로 회전합니다|
|PenUp PenDown|펜을 들거나 내립니다. 펜이 내려가있을 때, 움직이는 거북이는 선을 그립니다.|

## Object Oriented Turtle

데이터와 동작이 묶여있습니다

```fsharp
type Turtle() =
    let mutable currentPosition = initialPosition
    let mutable currentAngle = 0.0<Degrees>
    let mutable currentPenState = initialPenState

    member this.Move(distance) =
        Logger.info (sprintf "Move %0.1f" distance)
        let startPos = currentPosition
        //calculate new position
        let endPos = calcNewPosition distance currentAngle startPos
        //draw line if needed\
        if currentPenState = Down then
            Canvas.draw startPos endPos
        //update the state
        currentPosition <-endPos

    member this.Turn(angleToTurn) = 
        Logger.info (sprintf "Turn %0.1f" angleToTurn)
        //calculate new angle
        let newAngle = (currentAngle + angleToTurn) % 360.0<Degrees>

        //update the state
        currentAngle <- newAngle

    member this.PenUp() =
        Logger.info "Pen Up"
        currentPenState <- Up

    member this.PenUp() =
        Logger.info "Pen Down"
        currentPenState <- Down
```

사용례
```fsharp
let drawTriangle () = 
    let distance = 50.0
    let turtle = Turtle()
    turtle.Move distance
    turntle.Turn 120.0<Degrees>
    turtle.Move distance
    turntle.Turn 120.0<Degrees>
    turtle.Move distance
    turntle.Turn 120.0<Degrees>
    //back home at (0,0) with angle 0
```

### 장점과 단점

장점

- 친숙하다
  
단점

- Stateful하고, 블랙박스(결과가 나오는 게 없으니 어떤 동작을 하는 지 가늠하기 어려움)이다
- 구성(composition)하기 어렵다
- 하드코딩된 의존성(아직까지는, 이후 의존성 삽입으로 해결 가능)

## Abstract Data Turtle

데이터는 동작과 분리되었습니다
(객체지향 이전의 70년도 스타일)

```fsharp
type TurtleState = private{
    mutable position : Position
    mutable angle : float<Degrees>
    mutable penState : PenState
}

module Turtle = 
    let move distance state = ...
    let turn angleToTurn state = ...
    let penUp state = ...
    let penDown log state = ...
```

사용례
```fsharp
let drawTriangle() =
    let distance = 50.0
    let turtle = Turtle.create()
    Turtle.move distance turtle
    Turtle.turn 120.0<Degrees> turtle
    Turtle.move distance turtle
    Turtle.turn 120.0<Degrees> turtle
    Turtle.move distance turtle
    Turtle.turn 120.0<Degrees> turtle
```

### 장점과 단점

장점

- 간단하다
- 상속보다 구성(composition)을 강요한다

단점

- 객체지향과 같이, 상태적이고 블랙박스이다.

## Functional Turtle

데이터는 불변적이다

```fsharp
type TurtleState = {
    position: Position
    angle : float<Degrees>
    penState : PenState
}

module Turtle =
    let move distance state = ... //추상 데이터와 다르게 새 state를 반환
    let turn angleToTurn state = ... //추상 데이터와 다르게 새 state를 반환
    let penUp state = ... //추상 데이터와 다르게 새 state를 반환
    let penDown log state = ... //추상 데이터와 다르게 새 state를 반환
```

사용례
```fsharp
let drawTriangle()=
    Turtle.initialTurtleState
    |>Turtle.move 50.0
    |>Turtle.turn 120.0<Degrees>
    ...
```

### 장점과 단점

장점

- 불변성: 원인 파악이 쉽다. 블랙박스가 없다
- 상태가 없다: 테스트 하기 쉽다
- 함수들은 구성이 쉽다

단점

- 클라이언트는 항상 상태를 추적해야 한다
- 하드코딩된 의존성(아직까지는)

## State monad

화면 뒤의 스레딩 상태

만약 거북이가 네모의 가장자리에 닿으면 더 이상 가지 못한다고 하는 상황을 위하여 API를 바꿔보겠습니다.  
move의 반환값이 (새 상태*실제 이동한 거리)

다음은 함수형의 접근으로 새 API를 작성한 것입니다.
```fsharp
let s0 = Turtle.initialTurtleState
let (actualDistA,s1) = Turtle.move 80.0 s0
if actualDistA < 80.0 then
    printfn "first move failed -- turning"
    let s2 = Turtle.turn 120.0<Degrees> s1
    let (actualDistB,s3) = Turtle.move 80.0 s2
    ...
else
    printfn "first move succeeded"
    let (acutalDistC,s2) = Turtle.move 80.0 s1
    ...
```

위와 같이 분기를 따라 상태를 전달하는 것은 끔찍합니다. 반환값이 단순 상태가 아닌 pair이기 때문에 파이핑 또한 사용할 수 없습니다. 이런 상황이 있을 때 상태를 어떻게 계속 추적할 수 있을까요?

그래서 우리는 Turtle function을 수정해야 합니다.

기존의 Turtle function이  

>TurtleFunction(TurtleState input) -> (newTurtleState * Output)

의 형태였다면, 이를 

>f(input g(TurtleState)) -> (newTurtleState * Output)

의 형태로 `currying`를 합니다. 이를 추상화한다면 

>TurtleFunction(input) -> State<>

로 볼 수 있습니다. 이제 하나의 값을 반환하는 함수가 되었으니, 파이핑을 할 수 있습니다. 이를 사용하기 위해서는 별도의 특별한 `state expression`을 사용해야 합니다.

사용례

```fsharp
let stateExpression = state {
    let! distA = move 80.0
    if distA < 80.0 then
        printfn "first move failed --turning"
        do! turn 120.0<Degrees>
        ...
    else
        printfn "first move succeeded"
        let! distB = move 80.0
        ...
}
```

### 장점과 단점

장점

- 명령형 코드처럼 보이지만 불변성을 보전합니다.
- 함수들이 여전히 구성 가능합니다

단점

- 구현하고 사용하기 어렵습니다.

## Error handling

벽에 충돌하는 결과를 상정할 때, Turtle Function은 다음과 같이 정의할 수 있습니다.

> TurtleFunction(input TurtleState) -> (Success or Failure)

반환 값은 두 종류가 아닌 둘 중 하나이므로 이를 `Choice type` 로 표현하면 다음과 같습니다.

```fsharp
type Result<'successInfo,'errorInfo> =
    | Success of `successInfo
    | Failure of `errorInfo
```

이런 `Choice type`은 `Sum type`,`Descriminated Union type` 등으로 불리기도 합니다.

### Result를 이용한 구현

```fsharp
let move distanceRequested state =
    //calculate new position
    //draw line if needed
    if actualDistanceMoved <> distanceRequested then
        Failure "Moved out of bounds"
    else
        Success (state with poisition = endPosition)
```

이러한 다른 두 종류의 선택을 반환하는 것은 객체지향에서 쉽지 않습니다.

사용례

```fsharp
let s0 = Turtle.initialTurtleState
let result1 = s0 |> Turtle.move 80.0
match result1 with
| Success s1 ->
    let result2 = s1 |> Turtle.move 80.0
    match result2 with 
    | Success s2 ->
        ...
    | Failure msg ->
        printfn "second move failed %s" msg
| Failure msg ->
    printfn "second move failed %s" msg
```

이러한 구조를 반복하는 것은 아름답지 않습니다. 그래서 이를 result 계산식을 이용하여 재정의를 하면 다음과 같습니다.

```fsharp
let finalResult = result {
    let s0= Turtle.initialTurtleState
    let! s1 = s0 |> Turtle.move 80.0
    printfn "first move succeeded"
    let! s2 = s1 |> Turtle.move 30.0
    printfn "second movesucceeded"
    let! s3 = s2 |> Turtle.turn 120.0<Degrees>
    let! s4 = s3 |> Turtle.move 80.0
    printfn "third move succeeded"
    return()
}
```
위의 코드 중 하나라도 실패하는 것이 있다면, 다른 모든 라인을 무시하고 맨 아래의 라인으로 가게 될 것입니다. 위의 코드에서 상태를 계속 추적하는 것이 보입니다. 이를 상태와 결과를 합쳐서 표현하면 다음과 같습니다.

```fsharp
let finalResult = resultState{
    do! Turtle.move 80.0
    printfn "first move succeeded"
    do! Turtle.move 30.0
    printfn "second move succeeded"
    do! Turtle.turn 120.0<Degrees>
    do! Turtle.move 80.0
    printfn "third move succeeded"
    return ()
}
```

이는 객체지향에서의 명령형 코드처럼 보입니다. 그러나 객체지향과는 다르게 상태 관리와 에러 처리가 적용되어 있습니다.

### 장점과 단점

장점

- 에러가 명시적으로 반환됩니다(Exception이 없습니다)
- 지저분한 에러 처리 코드가 없습니다(try-catch등)

단점

- 구현하고 쓰기가 좀 어렵습니다

## Async Turtle

만약 turtle이 비동기로 호출되었다면?

```fsharp
let s0 = Turtle.initialTurtleState
s0|> Turtle.moveAsync 80.0 (fun s1 ->
    s1 |> Turtle.moveAsync 80.0 (fun s2 ->
        s2 |> Turtle.moveAsync 80.0 (fun s3 ->
        ...
        )
    )
)
```

비동기로 처리되는 코드에서는 작업이 끝나고 새 상태를 가지고 호출되는 콜백이 있습니다. 새 상태에서 다시 움직일때는 새 콜백을 이용합니다. 이는 비동기 코드가 있는 곳에서는 흔한 패턴입니다.

그래서 이걸 해결하기 위해 async 계산표현식을 이용합니다. 이는 콜백을 숨겨줍니다.

```fsharp
let finalResult = async {
    let s0 = Turtle.initialTurtleState
    let! s1 = s0 |> Turtle.moveAsync 80.0
    let! s2 = s1 |> Turtle.moveAsync 80.0
    let! s3 = s2 |> Turtle.moveAsync 80.0
    ...
}
```

그래서 위의 코드 상에서 비동기 호출을 할 때에, 걱정하지 않아도 알아서 다 처리됩니다. 일반 코드처럼 보여도, 비동기 호출이 전부 처리됩니다.

여기서 패턴이 보이시나요? 바로 모나드입니다.

지금까지 한 것들을 정리해 보겠습니다.

구성(Composition)
- 함수들을 체이닝하는 것

명확성(Explicitness)
- 명시적인 상태 관리(mutation이 없음)
- 명시적인 에러(예외가 없음)

화면 밖에서 상태/에러/콜백을 스레딩하는 기술(m-word)

## Batch commands

호출자가 상태관리를 어떻게 피할 수 있을까?

batch 프로세싱을 할 때는, 명령 집합을 만든 후, batch 프로세서에 전달합니다. 이는 클라이언트 관점에서 매우 바람직합니다.
<pre>
[클라이언트]                  [   batch runner   ] ->   (state)   -> [Turtle functions]  
            -> (명령 집합) -> [(실행)->(명령 순회)] <- (new state) <-
                                            ㄴ 여기에서 상태 추적
</pre>

여기서 문제가 있습니다. 각 명령들은 함수가 아닌 데이터입니다. 어떻게 함수를 데이터로 만들 수 있을까요? 이는 union 타입을 이용하여 간단하게 만들 수 있습니다


```fsharp
//api
let move distance
let turn float<Degrees>
let penUp()
let penDown()
```
```fsharp
//data
type TurtleCommand =
| Move of Distance
| Turn of Angle
| PenUp
| PenDown
```
그래서 우리는 이제 serialize 가능한 명령을 만들었습니다

사용례
```fsharp
let commands = [
    Move 100.0
    Turn 120.0<Degrees>
    Move 100.0
    Turn 120.0<Degrees>
    Move 100.0
]
```
이들은 함수 호출처럼 보이지만, 이들은 그냥 데이터일 뿐입니다. 이제 이 명령들을 배치 프로세서에게 넘기면, 이 명령들을 한번에 수행합니다.

```fsharp
TurtleBatch.run commands
```