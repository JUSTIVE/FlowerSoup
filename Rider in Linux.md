# Rider in Linux

## MSBuild compiler defines
MSbuild 를 이용한 빌드의 경우 fsharp 에서의 compiler option 인 `-d:symbol` 옵션을 사용하기 위해서는
rider 내의 `navigation search` -> `actions` -> `MSBuild global properties` -> `MSBuild global properties` 항목에 다음 값을 추가한다.

|name | value|
|---|---|
|DefineConstants|원하는 값|