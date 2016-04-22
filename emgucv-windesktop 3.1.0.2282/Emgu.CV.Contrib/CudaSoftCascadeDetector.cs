﻿/*
//----------------------------------------------------------------------------
//  Copyright (C) 2004-2016 by EMGU Corporation. All rights reserved.       
//----------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using Emgu.Util;
using Emgu.CV.Cuda;

namespace Emgu.CV.Softcascade
{
   /// <summary>
   /// Cuda Implementation of soft (stageless) cascaded detector.
   /// </summary>
   public class CudaSoftCascadeDetector : UnmanagedObject
   {

      /// <summary>
      /// Create a soft (stageless) cascaded detector.
      /// </summary>
      /// <param name="trainedCascadeFileName">File name of the trained soft cascade detector</param>
      /// <param name="minScale">A minimum scale relative to the original size of the image on which cascade will be applied. Use 0.4 for default.</param>
      /// <param name="maxScale">A maximum scale relative to the original size of the image on which cascade will be applied. Use 5.0 for default</param>
      /// <param name="scales">Number of scales from minScale to maxScale. Use 55 for default</param>
      /// <param name="flags">An extra tuning flags.</param>
      public CudaSoftCascadeDetector(String trainedCascadeFileName, 
         double minScale = 0.4, double maxScale = 5, int scales = 55, 
         SoftCascadeDetector.RejectionCriteria flags = SoftCascadeDetector.RejectionCriteria.NoReject)
      {
         using (CvString s = new CvString(trainedCascadeFileName))
            _ptr = SoftCascadeInvoke.cudaSoftCascadeDetectorCreate(s, minScale, maxScale, scales, flags);
      }

      /// <summary>
      /// Apply cascade to an input frame and return the array of decection objects.
      /// </summary>
      /// <param name="image">A frame on which detector will be applied.</param>
      /// <param name="rois">A regions of interests mask generated by genRoi. Only the objects that fall into one of the regions will be returned.</param>
      /// <param name="stream">Use a Stream to call the function asynchronously (non-blocking) or null to call the function synchronously (blocking).</param>  
      /// <returns>An array of decection objects</returns>
      public GpuMat Detect(CudaImage<Bgr, Byte> image, GpuMat<int> rois, Emgu.CV.Cuda.Stream stream = null)
      {
         GpuMat result = new GpuMat();
         SoftCascadeInvoke.cudaSoftCascadeDetectorDetect(_ptr, image, rois, result, stream);
         return result;
      }

      /// <summary>
      /// Release all the unmanaged memory associated with this cascade classifier
      /// </summary>
      protected override void DisposeObject()
      {
         if (_ptr != IntPtr.Zero)
            SoftCascadeInvoke.cudaSoftCascadeDetectorRelease(ref _ptr);
      }
   }

   internal static partial class SoftCascadeInvoke
   {
      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static IntPtr cudaSoftCascadeDetectorCreate(
         IntPtr fileName,
         double minScale, double maxScale, int scales, SoftCascadeDetector.RejectionCriteria flags);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void cudaSoftCascadeDetectorDetect(IntPtr detector, IntPtr image, IntPtr rois, IntPtr detectionGpuMat, IntPtr stream);

      [DllImport(CvInvoke.ExternLibrary, CallingConvention = CvInvoke.CvCallingConvention)]
      internal extern static void cudaSoftCascadeDetectorRelease(ref IntPtr detector);
   }
}
*/