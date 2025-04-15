using UnityEngine;
using UnityEngine.UI;

public class VampirismBar : MonoBehaviour
{
   [SerializeField] private Vampirism _vampirism;

   private Slider _slider;
   
   private void Awake()
   {
      _slider = GetComponent<Slider>();
      _slider.value = _slider.maxValue;
   }

   private void OnEnable() =>
      _vampirism.OnCooldownProgress += UpdateCooldownUI;

   private void OnDisable() =>
      _vampirism.OnCooldownProgress -= UpdateCooldownUI;

   private void UpdateCooldownUI(float progress) =>
      _slider.value = progress * _slider.maxValue;
}

