using BattleshipV2.BLL.Requests;
using BattleshipV2.BLL.Responses;
using BattleshipV2.BLL.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleshipV2.BLL.GameLogic
{
    public class Board
    {
        Board PlayerBoard { get; set; }

        //int that keeps track of the # of ships?
        private int _currentShipIndex;

        //create a private dictionary that will hold the corrdinates and shot history (in order to build the board)
        private Dictionary<Coordinates, ShotHistory> ShotHistory;

        //create a public array of ship objects to store the ships placed on the board
        public Ship[] Ships { get; private set; }

        //create a constructor 
        public Board()
        {
            ShotHistory = new Dictionary<Coordinates, ShotHistory>();
            Ships = new Ship[5];
            _currentShipIndex = 0;
        }

        public FireShotResponse FireShot(Coordinates coordinate)
        {
            var response = new FireShotResponse();

            //is this coordinate on the board?
            if (!isValidCoordinate(coordinate))
            {
                response.Status = ShotStatus.Invalid;
                return response;
            }

            //did they already try this position?
            if (ShotHistory.ContainsKey(coordinate))
            {
                response.Status = ShotStatus.Duplicate;
                return response;
            }

            //check ships for hits or victory
            CheckForHits(coordinate, response);
            CheckForVictory(response);

            return response;
        }

        private void CheckForVictory(FireShotResponse response)
        {
            if(response.Status == ShotStatus.HitAndSunk)
            {
                if(Ships.All(s => s.isSunk))
                {
                    response.Status = ShotStatus.Victory;
                }
            }
        }

        private void CheckForHits(Coordinates coordinate, FireShotResponse response)
        {
            response.Status = ShotStatus.Miss;

            foreach(var ship in Ships)
            {
                //no need to check sunk ships
                if (ship.isSunk)
                {
                    continue;
                }
                ShotStatus status = ship.FireAtShip(coordinate);

                switch (status)
                {
                    case ShotStatus.HitAndSunk:
                        response.Status = ShotStatus.HitAndSunk;
                        response.ShipImpacted = ship.ShipName;
                        ShotHistory.Add(coordinate, Responses.ShotHistory.Hit);
                        break;
                    case ShotStatus.Hit:
                        response.Status = ShotStatus.Hit;
                        response.ShipImpacted = ship.ShipName;
                        ShotHistory.Add(coordinate, Responses.ShotHistory.Hit);
                        break;
                }
                //if they hit something no need to continue looping
                if (status != ShotStatus.Miss)
                    break;
            }
            if(response.Status == ShotStatus.Miss)
            {
                ShotHistory.Add(coordinate, Responses.ShotHistory.Miss);
            }
        }

        private bool isValidCoordinate(Coordinates coordinate)
        {
            return coordinate.XCoordinate >= 1 && coordinate.XCoordinate <= 10 &&
                   coordinate.YCoordinate >= 1 && coordinate.YCoordinate <= 10;
        }

        //create a 
        public ShipPlacement PlaceShip(PlacementRequest request)
        {
            if(_currentShipIndex > 4)
            {
                throw new Exception("You cannot add another ship, 5 is the limit!");
            }
            if (!isValidCoordinate(request.Coordinate))
            {
                return ShipPlacement.NotEnoughSpace;
            }

            Ship newShip = ShipCreation.CreateShip(request.SelectedShip);
            switch (request.Direction)
            {
                case ShipDirection.Down:
                    return PlaceShipDown(request.Coordinate, newShip);
                case ShipDirection.Up:
                    return PlaceShipUp(request.Coordinate, newShip);
                case ShipDirection.Right:
                    return PlaceShipRight(request.Coordinate, newShip);
                default:
                    return PlaceShipLeft(request.Coordinate, newShip);                        
            }
        }

        private ShipPlacement PlaceShipLeft(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int minY = coordinate.YCoordinate - newShip.BoardPositions.Length;

            for(int i = coordinate.YCoordinate; i > minY; i--)
            {
                var currentCoordinate = new Coordinates(coordinate.XCoordinate, i);
                
                if(!isValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }
                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }
                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToBoard(newShip);
            return ShipPlacement.OK;
        }

        private ShipPlacement PlaceShipRight(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int maxY = coordinate.YCoordinate + newShip.BoardPositions.Length;

            for(int i = coordinate.YCoordinate; i < maxY; i++)
            {
                var currentCoordinate = new Coordinates(coordinate.XCoordinate, i);
                if (!isValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }
                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }

                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToBoard(newShip);
            return ShipPlacement.OK;
            
        }

        private void AddShipToBoard(Ship newShip)
        {
            Ships[_currentShipIndex] = newShip;
            _currentShipIndex++;
        }

        private bool OverlapsAnotherShip(Coordinates coordinate)
        {
            foreach(var ship in Ships)
            {
                if(ship != null)
                {
                    if (ship.BoardPositions.Contains(coordinate))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private ShipPlacement PlaceShipUp(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int minX = coordinate.YCoordinate - newShip.BoardPositions.Length;

            for(int i = coordinate.XCoordinate; i > minX; i--)
            {
                var currentCoordinate = new Coordinates(i,coordinate.YCoordinate);

                if (!isValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }
                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }
                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToBoard(newShip);
            return ShipPlacement.OK;

        }

        private ShipPlacement PlaceShipDown(Coordinates coordinate, Ship newShip)
        {
            int positionIndex = 0;
            int maxX = coordinate.XCoordinate + newShip.BoardPositions.Length;

            for(int i = coordinate.YCoordinate; i < maxX; i++)
            {
                var currentCoordinate = new Coordinates(coordinate.XCoordinate, i);

                if (!isValidCoordinate(currentCoordinate))
                {
                    return ShipPlacement.NotEnoughSpace;
                }
                if (OverlapsAnotherShip(currentCoordinate))
                {
                    return ShipPlacement.Overlap;
                }
                newShip.BoardPositions[positionIndex] = currentCoordinate;
                positionIndex++;
            }
            AddShipToBoard(newShip);
            return ShipPlacement.OK;
        }
    }
}
