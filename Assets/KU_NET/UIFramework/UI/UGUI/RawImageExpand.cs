﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
namespace Kubility
{
	[AddComponentMenu("KUI/RawImage",11)]
	public class RawImageExpand :RawImage 
	{
		protected override void Awake ()
		{
			base.Awake ();
		}

		protected override void OnEnable ()
		{
			base.OnEnable ();
		}

		protected override void Start ()
		{
			base.Start ();
		}

		protected override void OnDisable ()
		{
			base.OnDisable ();
		}

		protected override void OnDestroy ()
		{
			base.OnDestroy ();
		}

		public override bool IsActive ()
		{
			return base.IsActive ();
		}


		protected override void OnRectTransformDimensionsChange ()
		{
			base.OnRectTransformDimensionsChange ();
		}

		protected override void OnBeforeTransformParentChanged ()
		{
			base.OnBeforeTransformParentChanged ();
		}

		protected override void OnTransformParentChanged ()
		{
			base.OnTransformParentChanged ();
		}

		protected override void OnDidApplyAnimationProperties ()
		{
			base.OnDidApplyAnimationProperties ();
		}

		protected override void OnCanvasGroupChanged ()
		{
			base.OnCanvasGroupChanged ();
		}

		protected override void OnCanvasHierarchyChanged ()
		{
			base.OnCanvasHierarchyChanged ();
		}

		public override void SetAllDirty ()
		{
			base.SetAllDirty ();
		}

		public override void SetLayoutDirty ()
		{
			base.SetLayoutDirty ();
		}

		public override void SetVerticesDirty ()
		{
			base.SetVerticesDirty ();
		}

		public override void SetMaterialDirty ()
		{
			base.SetMaterialDirty ();
		}

		public override void LayoutComplete ()
		{
			base.LayoutComplete ();
		}

		public override void GraphicUpdateComplete ()
		{
			base.GraphicUpdateComplete ();
		}


		public override void SetNativeSize ()
		{
			base.SetNativeSize ();
		}

		public override bool Raycast (Vector2 sp, Camera eventCamera)
		{
			return base.Raycast (sp, eventCamera);
		}



		public override Material defaultMaterial {
			get {
				return base.defaultMaterial;
			}
		}


		public override Material GetModifiedMaterial (Material baseMaterial)
		{
			return base.GetModifiedMaterial (baseMaterial);
		}

		public override void Cull (Rect clipRect, bool validRect)
		{
			base.Cull (clipRect, validRect);
		}

		public override void SetClipRect (Rect clipRect, bool validRect)
		{
			base.SetClipRect (clipRect, validRect);
		}

		[System.Obsolete ("Not used anymore.")]
		public override void ParentMaskStateChanged ()
		{
			base.ParentMaskStateChanged ();
		}

		public override void RecalculateClipping ()
		{
			base.RecalculateClipping ();
		}

		public override void RecalculateMasking ()
		{
			base.RecalculateMasking ();
		}

	}
}


