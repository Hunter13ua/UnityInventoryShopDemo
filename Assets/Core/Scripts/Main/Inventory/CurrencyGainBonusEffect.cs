using System;
using UnityEngine;

namespace Demo
{
    // ideally create some kind of IEffect for flexibility and inherit it
    // but im getting tired so a single effect as an example
    public class CurrencyGainBonusEffect
    {
        private const int Multiplier = 5;

        private float _currentTimer = 0;
        private float _previousTimerValue = 0;

        public event Action<int> OnTimerChanged;

        public int GetCurrentEffectMultiplier()
        {
            return _currentTimer > 0 ? Multiplier : 1;
        }

        public void UpdateTick()
        {
            if (_currentTimer > 0)
            {
                _currentTimer -= Time.deltaTime;

                if (_currentTimer <= 0 && _currentTimer < _previousTimerValue)
                {
                    _currentTimer = 0;
                }

                _previousTimerValue = _currentTimer;
                OnTimerChanged?.Invoke(Mathf.FloorToInt(_currentTimer));
            }
        }

        public void AddTimer(float value)
        {
            _currentTimer += value;
        }
    }
}