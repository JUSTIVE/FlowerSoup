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

네모 안에 거북이가 있다고 치고, 이 거북이가 움직이면서 선을 그릴 것입니다.
사용될 API는 다음과 같습니다.
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
 - Stateful하고, 블랙박스(결과가 나오는 게 없으니 어떤 동작을 하는 지 가늠하기 어려움)
 - 