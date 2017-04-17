namespace VRTK.Examples
{
    using UnityEngine;
    using UnityEventHelper;

    public class oeControlReactor : MonoBehaviour
    {
        public int indexData;
        public TextMesh go;

        private VRTK_Control_UnityEvents controlEvents;

        private void Start()
        {
            controlEvents = GetComponent<VRTK_Control_UnityEvents>();
            if (controlEvents == null)
            {
                controlEvents = gameObject.AddComponent<VRTK_Control_UnityEvents>();
            }

            controlEvents.OnValueChanged.AddListener(HandleChange);
        }

        private void HandleChange(object sender, Control3DEventArgs e)
        {
            go.text = e.value.ToString() + "(" + ((int)e.normalizedValue).ToString() + "%)";

            oeCommonDataContainer.setArrInt(indexData, (int)e.normalizedValue);
        }
    }
}