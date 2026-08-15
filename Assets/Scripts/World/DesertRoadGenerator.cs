using UnityEngine;

namespace Progo.World
{
    public sealed class DesertRoadGenerator : MonoBehaviour
    {
        [SerializeField] private int segmentCount = 40;
        [SerializeField] private float segmentLength = 50f;
        [SerializeField] private float roadWidth = 10f;
        [SerializeField] private float desertWidth = 120f;
        [SerializeField] private Material roadMaterial;
        [SerializeField] private Material desertMaterial;

        [ContextMenu("Generate Road")]
        public void Generate()
        {
            ClearGenerated();

            for (int i = 0; i < segmentCount; i++)
            {
                float z = i * segmentLength;
                CreatePrimitive("RoadSegment", PrimitiveType.Cube, new Vector3(0f, -0.15f, z), new Vector3(roadWidth, 0.3f, segmentLength + 0.1f), roadMaterial);
                CreatePrimitive("DesertLeft", PrimitiveType.Cube, new Vector3(-(desertWidth + roadWidth) * 0.5f, -0.3f, z), new Vector3(desertWidth, 0.2f, segmentLength), desertMaterial);
                CreatePrimitive("DesertRight", PrimitiveType.Cube, new Vector3((desertWidth + roadWidth) * 0.5f, -0.3f, z), new Vector3(desertWidth, 0.2f, segmentLength), desertMaterial);
            }
        }

        [ContextMenu("Clear Generated")]
        public void ClearGenerated()
        {
            for (int i = transform.childCount - 1; i >= 0; i--)
            {
#if UNITY_EDITOR
                if (!Application.isPlaying) DestroyImmediate(transform.GetChild(i).gameObject);
                else Destroy(transform.GetChild(i).gameObject);
#else
                Destroy(transform.GetChild(i).gameObject);
#endif
            }
        }

        private void CreatePrimitive(string objectName, PrimitiveType type, Vector3 position, Vector3 scale, Material material)
        {
            GameObject obj = GameObject.CreatePrimitive(type);
            obj.name = objectName;
            obj.transform.SetParent(transform, false);
            obj.transform.SetPositionAndRotation(position, Quaternion.identity);
            obj.transform.localScale = scale;
            if (material != null) obj.GetComponent<Renderer>().sharedMaterial = material;
        }
    }
}
