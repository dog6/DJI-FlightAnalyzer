using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneFlightAnalyzer
{ 
        public static class VideoEncoder
        {
            public static string H264_NVENC = "h264_nvenc";
            public static string H264_AMF = "h264_amf";
            public static string HEVC_AMF = "hevc_amf";
            public static string H264_VAAPI = "h264_vaapi";
            public static string HEVC_VAAPI = "hevc_vaapi";
            public static string LIBX264 = "libx264";
            public static string LIBX265 = "libx265";
            public static string SelectedEncoder = LIBX264;
            public static string[] Encoders = { H264_NVENC, H264_AMF, H264_VAAPI, HEVC_AMF, HEVC_VAAPI, LIBX264, LIBX265 };
        }

}
