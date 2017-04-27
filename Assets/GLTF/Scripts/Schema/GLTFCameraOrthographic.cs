using System;
using Newtonsoft.Json;

namespace GLTF
{
	/// <summary>
	/// An orthographic camera containing properties to create an orthographic
	/// projection matrix.
	/// </summary>
	public class GLTFCameraOrthographic : GLTFProperty
	{
        /// <summary>
        /// The floating-point horizontal magnification of the view.
        /// </summary>
        public double XMag;

        /// <summary>
        /// The floating-point vertical magnification of the view.
        /// </summary>
        public double YMag;

        /// <summary>
        /// The floating-point distance to the far clipping plane.
        /// </summary>
        public double ZFar;

        /// <summary>
        /// The floating-point distance to the near clipping plane.
        /// </summary>
        public double ZNear;

        public static GLTFCameraOrthographic Deserialize(GLTFRoot root, JsonTextReader reader)
        {
            var cameraOrthographic = new GLTFCameraOrthographic();

            if (reader.Read() && reader.TokenType != JsonToken.StartObject)
            {
                throw new Exception("Orthographic camera must be an object.");
            }

            while (reader.Read() && reader.TokenType == JsonToken.PropertyName)
            {
                var curProp = reader.Value.ToString();

                switch (curProp)
                {
                    case "xmag":
                        cameraOrthographic.XMag = reader.ReadAsDouble().Value;
                        break;
                    case "ymag":
                        cameraOrthographic.YMag = reader.ReadAsDouble().Value;
                        break;
                    case "zfar":
                        cameraOrthographic.ZFar = reader.ReadAsDouble().Value;
                        break;
                    case "znear":
                        cameraOrthographic.ZNear = reader.ReadAsDouble().Value;
                        break;
	                default:
		                cameraOrthographic.DefaultPropertyDeserializer(root, reader);
		                break;
				}
            }

            return cameraOrthographic;
        }
    }
}
