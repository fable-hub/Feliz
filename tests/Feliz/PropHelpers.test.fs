module PropHelperTests

open Feliz
open System
open Vitest

describe "PropHelpers Tests" <| fun _ ->

    test "createClockValue returns a valid result" <| fun _ ->
        expect(PropHelpers.createClockValue(TimeSpan(0,0,0,15,1))).toEqual "00:00:15.01" 
        expect(PropHelpers.createClockValue(TimeSpan(13,21,0))).toEqual "13:21:00.00"
        expect(PropHelpers.createClockValue(TimeSpan(23,0,50))).toEqual "23:00:50.00"
        expect(PropHelpers.createClockValue(TimeSpan(0,0,8,34,20))).toEqual "00:08:34.20"

    test "createKeySplines returns a valid result" <| fun _ ->
        let expected = "0 1.5 2 3; 4 5 6.5 7"

        let actual = PropHelpers.createKeySplines([0.,1.5,2.,3.; 4.,5.,6.5,7.])
        
        expect(actual).toEqual expected

    test "createPoints returns a valid result" <| fun _ ->
        let expected = "1,2 3,4"
        
        let actualFloat = PropHelpers.createPointsFloat([1.,2.;3.,4.])
        let actualInt = PropHelpers.createPointsInt([1,2;3,4])

        expect(actualFloat).toEqual expected
        expect(actualInt).toEqual expected

    test "createSvgPath returns a valid result" <| fun _ ->
        let expected = 
            [ "M 10,30" 
              "A 20,20 0,0,1 50,30"
              "A 20,20 0,0,1 90,30"
              "Q 90,60 50,90"
              "Q 10,60 10,30" 
              "z" ]
            |> String.concat System.Environment.NewLine
        
        let actualFloat = 
            PropHelpers.createSvgPathFloat([
                'M', [[10.;30.]]
                'A', [[20.;20.]; [0.;0.;1.]; [50.;30.]]
                'A', [[20.;20.]; [0.;0.;1.]; [90.;30.]]
                'Q', [[90.;60.]; [50.;90.]]
                'Q', [[10.;60.]; [10.;30.]]
                'z', []
            ])
        let actualInt =
            PropHelpers.createSvgPathInt([
                'M', [[10;30]]
                'A', [[20;20]; [0;0;1]; [50;30]]
                'A', [[20;20]; [0;0;1]; [90;30]]
                'Q', [[90;60]; [50;90]]
                'Q', [[10;60]; [10;30]]
                'z', []
            ])

        expect(actualFloat).toEqual expected
        expect(actualInt).toEqual expected
