﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Deform.Deformers
{
	public class SkewDeformer : DeformerComponent
	{
		public float amount = 1f;
		public Transform axis;

		private Matrix4x4
			axisSpace,
			inverseAxisSpace;

		public override void PreModify ()
		{
			base.PreModify ();

			// Ensure there's an axis.
			if (axis == null)
			{
				axis = new GameObject ("SkewAxis").transform;
				axis.transform.SetParent (transform);
				axis.transform.Rotate (0f, -90f, 0f);
				axis.transform.localPosition = Vector3.zero;
			}

			axisSpace = Matrix4x4.TRS (Vector3.zero, Quaternion.Inverse (axis.rotation) * transform.rotation, Vector3.one);
			inverseAxisSpace = axisSpace.inverse;
		}

		public override VertexData[] Modify (VertexData[] vertexData, TransformData transformData, Bounds meshBounds)
		{
			for (int vertexIndex = 0; vertexIndex < vertexData.Length; vertexIndex++)
			{
				var position = axisSpace.MultiplyPoint3x4 (vertexData[vertexIndex].position);
				position.z += position.y * amount;
				vertexData[vertexIndex].position = inverseAxisSpace.MultiplyPoint3x4 (position);
			}
			return vertexData;
		}
	}
}