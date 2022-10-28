using Sirenix.OdinInspector;
using UnityEngine;

namespace Template.Utilities.PrefabLightmapping_master {
    public class MeshModifier: MonoBehaviour {


        [Button]
        public void Modify() {
            Mesh meshToModify = GetComponent<MeshFilter>().sharedMesh;
            Vector4 lightmapOffsetAndScale = GetComponent<Renderer>().lightmapScaleOffset;

            Vector2[] modifiedUV2s = meshToModify.uv2;
            for (int i = 0; i < meshToModify.uv2.Length; i++) {
                modifiedUV2s[i] = new Vector2(meshToModify.uv2[i].x * lightmapOffsetAndScale.x +
                                              lightmapOffsetAndScale.z,
                    meshToModify.uv2[i].y * lightmapOffsetAndScale.y +
                    lightmapOffsetAndScale.w);
            }

            meshToModify.uv2 = modifiedUV2s;
        }
    }
}