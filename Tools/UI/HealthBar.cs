using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace KagnousLib
{
    /// <summary>
    /// Permet de gérer des slider reliés à un int
    /// </summary>
    [AddComponentMenu(Constants.LIB + "/My UI/Barre de vie")]
    [HelpURL(Constants.DEFAULT_HELP_URL)]
    public class HealthBar : MonoBehaviour
    {
        /// <summary>
        /// Component slider de l'objet
        /// </summary>
        private Slider _slider;

        /// <summary>
        /// Image de ce qui remplit la barre
        /// </summary>
        private Image _fill;

        [SerializeField, Tooltip("Dégradé de couleur du slider")]
        private Gradient _gradient;

        private void Awake()
        {
            if (_slider == null)
                _slider = GetComponent<Slider>();
            if (_fill == null)
                _fill = transform.Find("Fill").GetComponent<Image>();
        }

        /// <summary>
        /// Set la valeur max de la barre et la met à cette valeur
        /// </summary>
        /// <param name="value">Valeur max de la vie</param>
        public void SetMaxHealth(int value)
        {
            _slider.maxValue = value;
            _slider.value = value;

            _fill.color = _gradient.Evaluate(1f);
        }

        /// <summary>
        /// Set la barre à la valeur donnée
        /// </summary>
        /// <param name="value">Nouvelle valeur de la vie</param>
        public void SetHealth(int value)
        {
            _slider.value = value;

            _fill.color = _gradient.Evaluate(_slider.normalizedValue);
        }
    }
}