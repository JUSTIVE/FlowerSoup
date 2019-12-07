# Functional Programming

1장에서 보았듯 순수 함수형 프로그래밍은 함수를 포함한 모든 것들을 값으로 봅니다. 비록 F#은 순수 함수형 프로그래밍 언어는 아니지만 부작용을 지니는 선언 대신 값을 반환하는 표현이나 계산들을 반환하는 것처럼 함수형 스타일로 작성할 수 있게 합니다. 이 장에서는 F#에서 함수형 프로그래밍을 지원하게 하는 대부분의 구성요소들을 만나고 그것들이 함수형 프로그래밍을 쉽게 하는 것을 배울 것입니다.

## 리터럴

리터럴은 상수 값을 의미하며, 계산에 유용한 블록들입니다. F#은 다양한 리터럴을 지원합니다.

|예시|F#타입|.Net 타입|설명|
|---|---|---|---|
|"Hello\t","World\n"|string|System.String|이스케이프 문자(\)를 포함한 문자열입니다|
|@"c:\dir\fs",@""""|string|System.String|축자(verbatim) 문자열입니다. (\)는 일반 문자로 취급됩니다|
|"bytesbytesbytes"B|byte array|System.Byte|바이트 배열로 저장될 문자열입니다|
|'c'|char|System.Char|문자입니다|
|true,false|bool|System.Boolean|불리언 값입니다|
|0x22|int/int32|System.Int32|16진수 정수입니다|
|0o42|int/int32|System.Int32|8진수 정수입니다|
|0b10010|int/int32|System.Int32|2진수 정수입니다|
|34y|sbyte|System.SByte|부호를 가진 바이트입니다|
