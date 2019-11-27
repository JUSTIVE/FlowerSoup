# Primitive Type

## double 과 float
double 과 float은 사실상 같다(64-bit floating number), alias라고 생각하면 된다.

## +의 함정
다음의 코드는 유효하다
```F#
1 + 1
```
```F#
1+ 1
```

그러나 다음의 코드는 유효하지 않다
```F#
1 +1
```

이는 `+1`을 `signed int (+1)`로 보기 때문. 