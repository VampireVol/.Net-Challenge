using System;
using System.Threading;

namespace Tennis
{
    public class Tennis
    {
        private Random _rnd;
        private const int MaxRoll = 20;
        private int _skillFirstPlayer;
        private int _skillSecondPlayer;

        private GamePoints _gamePointsFirst;
        private GamePoints _gamePointsSecond;

        private int _setGamesFirst = 0;
        private int _setGamesSecond = 0;

        private int _setPointsFirst = 0;
        private int _setPointsSecond = 0;

        private bool _tiebreakerGame = false;
        private int _tiebreakerPointsFirst = 0;
        private int _tiebreakerPointsSecond = 0;

        public Tennis(Random rnd, int skillFirstPlayer, int skillSecondPlayer)
        {
            _rnd = rnd;
            _skillFirstPlayer = skillFirstPlayer;
            _skillSecondPlayer = skillSecondPlayer;
        }

        public void StartSimulation()
        {
            while (IsEndSimulation())
            {
                _setGamesFirst = 0;
                _setGamesSecond = 0;
                bool firstWin = StartSet();
                if (firstWin)
                {
                    _setPointsFirst++;
                }
                else
                {
                    _setPointsSecond++;
                }
            }

            Console.Clear();
            Console.WriteLine(this);
            if (_setPointsFirst == 2)
            {
                Console.WriteLine("Победил первый игорк!");
            }
            else
            {
                Console.WriteLine("Победил второй игрок!");
            }
        }

        private bool IsEndSimulation()
        {
            return _setPointsFirst != 2 && _setPointsSecond != 2;
        }

        private bool StartSet()
        {
            if (_tiebreakerGame) //Если был тай-брейк, но игра не закончилась
            {
                _tiebreakerGame = false;
            }

            while (IsSetEnd())
            {
                _gamePointsFirst = new GamePoints();
                _gamePointsSecond = new GamePoints();
                StartGame();
                if (_gamePointsFirst.Points == 60)
                {
                    _setGamesFirst++;
                }
                else
                {
                    _setGamesSecond++;
                }
            }

            if (_setGamesFirst == 6 && _setGamesSecond == 5
                || _setGamesFirst == 5 && _setGamesSecond == 6)
            {
                return SpecialSet();
            }

            if (_setGamesFirst == 6)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private bool IsSetEnd()
        {
            return _setGamesFirst != 6 && _setGamesSecond != 6;
        }

        private bool SpecialSet()
        {
            _gamePointsFirst = new GamePoints();
            _gamePointsSecond = new GamePoints();
            StartGame();
            if (_gamePointsFirst.Points == 60)
            {
                _setGamesFirst++;
            }
            else
            {
                _setGamesSecond++;
            }

            if (_setGamesFirst == _setGamesSecond)
            {
                if (_setPointsFirst == 1 && _setPointsSecond == 1)
                {
                    return StartFinalSet();
                }
                else
                {
                    return StartTiebreaker();
                }
            }

            if (_setGamesFirst == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool StartFinalSet()
        {
            while (IsFinalSetEnd())
            {
                _gamePointsFirst = new GamePoints();
                _gamePointsSecond = new GamePoints();
                StartGame();
                if (_gamePointsFirst.Points == 60)
                {
                    _setGamesFirst++;
                }
                else
                {
                    _setGamesSecond++;
                }
            }

            if (_setGamesFirst > _setGamesSecond)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsFinalSetEnd()
        {
            return Math.Abs(_setGamesFirst - _setGamesSecond) != 2;
        }

        private bool StartTiebreaker()
        {
            _tiebreakerGame = true;
            while (IsTiebreakerEnd())
            {
                Console.Clear();
                Console.WriteLine(this);
                if (IsFirstPlayerWin())
                {
                    _tiebreakerPointsFirst++;
                }
                else
                {
                    _tiebreakerPointsSecond++;
                }

                //Console.ReadKey();
                Thread.Sleep(1000);
            }
            if (_tiebreakerPointsFirst > _tiebreakerPointsSecond)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsTiebreakerEnd()
        {
            return (_tiebreakerPointsFirst < 7 && _tiebreakerPointsSecond < 7) ||
                   Math.Abs(_tiebreakerPointsFirst - _tiebreakerPointsSecond) < 2;
        }

        private void StartGame()
        {
            while (IsGameEnd())
            {
                Console.Clear();
                Console.WriteLine(this);
                if (IsFirstPlayerWin())
                {
                    GamePointsManager(_gamePointsFirst, _gamePointsSecond);
                }
                else
                {
                    GamePointsManager(_gamePointsSecond, _gamePointsFirst);
                }

                //Console.ReadKey();
                Thread.Sleep(1000);
            }
        }

        private void GamePointsManager(GamePoints first, GamePoints second)
        {
            if (second.Domination)
            {
                second.Domination = false;
                first.Domination = true;
            }
            else if (first.Domination)
            {
                first.Add();
            }
            else if (first.Points == 40 &&
                     second.Points == 40)
            {
                first.Domination = true;
            }
            else
            {
                first.Add();
            }
        }

        private bool IsGameEnd()
        {
            return _gamePointsFirst.Points != 60 && _gamePointsSecond.Points != 60;
        }

        public bool IsFirstPlayerWin()
        {
            int firstRoll = _rnd.Next(MaxRoll) + _skillFirstPlayer;
            int secondRoll = _rnd.Next(MaxRoll) + _skillSecondPlayer;
            return firstRoll > secondRoll;
        }

        public override string ToString()
        {
            if (_tiebreakerGame)
            {
                return $"Матч 3-сетовый между:\n" +
                       $"Первым игроком ({_skillFirstPlayer} лвл)\n" +
                       $"Вторым игроком ({_skillSecondPlayer} лвл)\n" +
                       $"Счет:\n" +
                       $"{_setPointsFirst} {_setGamesFirst} {_tiebreakerPointsFirst}\n" +
                       $"{_setPointsSecond} {_setGamesSecond} {_tiebreakerPointsSecond}";
            }
            else
            {
                return $"Матч 3-сетовый между:\n" +
                       $"Первым игроком ({_skillFirstPlayer} лвл)\n" +
                       $"Вторым игроком ({_skillSecondPlayer} лвл)\n" +
                       $"Счет:\n" +
                       $"{_setPointsFirst} {_setGamesFirst} {_gamePointsFirst}\n" +
                       $"{_setPointsSecond} {_setGamesSecond} {_gamePointsSecond}";
            }
        }
    }
}