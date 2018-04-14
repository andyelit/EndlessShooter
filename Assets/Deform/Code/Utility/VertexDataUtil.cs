﻿using System.Collections.Generic;
using UnityEngine;

namespace Deform
{
	public static class VertexDataUtil
	{
		/// <summary>
		/// Applies the givent vertex data to a mesh.
		/// </summary>
		public static void ApplyVertexData (VertexData[] vertexData, Mesh mesh)
		{
			var vertices = new Vector3[vertexData.Length];
			var vertexCount = vertexData.Length;

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				vertices[vertexIndex] = vertexData[vertexIndex].position;

			mesh.vertices = vertices;
		}

		public static VertexData[] GetVertexData (Mesh mesh)
		{
			var vertexCount = mesh.vertexCount;
			var vertexData = new VertexData[vertexCount];

			var vertices = mesh.vertices;

			var normals = mesh.normals;
			if (normals == null || normals.Length == 0)
				normals = new Vector3[vertexCount];

			var tangents = mesh.tangents;
			if (tangents == null | tangents.Length == 0)
				tangents = new Vector4[vertexCount];

			var uvs = mesh.uv;
			if (uvs == null || uvs.Length == 0)
				uvs = new Vector2[vertexCount];

			var colors = mesh.colors;
			if (colors == null || colors.Length == 0)
				colors = new Color[vertexCount];

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				vertexData[vertexIndex] = new VertexData (
					vertices[vertexIndex], 
					normals[vertexIndex], 
					tangents[vertexIndex], 
					uvs[vertexIndex], 
					colors[vertexIndex]);

			return vertexData;
		}

		public static Bounds GetBounds (VertexData[] vertexData)
		{
			var bounds = new Bounds ();
			for (int vertexIndex = 0; vertexIndex < vertexData.Length; vertexIndex++)
				bounds.Encapsulate (vertexData[vertexIndex].position);
			return bounds;
		}

		public static Vector3[] GetBasePositions (VertexData[] vertexData)
		{
			var vertexCount = vertexData.Length;
			var basePositions = new Vector3[vertexCount];

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				basePositions[vertexIndex] = vertexData[vertexIndex].basePosition;

			return basePositions;
		}

		public static Vector3[] GetPositions (VertexData[] vertexData)
		{
			var vertexCount = vertexData.Length;
			var positions = new Vector3[vertexCount];

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				positions[vertexIndex] = vertexData[vertexIndex].position;

			return positions;
		}

		public static Vector3[] GetNormals (VertexData[] vertexData)
		{
			var vertexCount = vertexData.Length;
			var normals = new Vector3[vertexCount];

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				normals[vertexIndex] = vertexData[vertexIndex].normal;

			return normals;
		}

		public static Vector3[] GetTangents (VertexData[] vertexData)
		{
			var vertexCount = vertexData.Length;
			var tangents = new Vector3[vertexCount];

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				tangents[vertexIndex] = vertexData[vertexIndex].tangent;

			return tangents;
		}

		public static Color[] GetColors (VertexData[] vertexData)
		{
			var vertexCount = vertexData.Length;
			var colors = new Color[vertexCount];

			for (int vertexIndex = 0; vertexIndex < vertexCount; vertexIndex++)
				colors[vertexIndex] = vertexData[vertexIndex].color;

			return colors;
		}

		public static VertexData[] ResetVertexData (VertexData[] vertexData)
		{
			for (int vertexIndex = 0; vertexIndex < vertexData.Length; vertexIndex++)
				vertexData[vertexIndex].ResetPosition ();

			return vertexData;
		}
	}
}