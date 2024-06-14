using System.Collections;
using System.Collections.Generic;

namespace ViewModel
{
    public class CharacterStateViewModel
    {
        private int _characterHp;

        public int CharacterHp
        {
            get { return _characterHp; }
            set
            {
                if (_characterHp == value)
                    return;

                _characterHp = value;
            }
        }

    }
}

