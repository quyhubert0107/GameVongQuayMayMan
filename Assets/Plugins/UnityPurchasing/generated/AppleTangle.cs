#if UNITY_ANDROID || UNITY_IPHONE || UNITY_STANDALONE_OSX || UNITY_TVOS
// WARNING: Do not modify! Generated file.

namespace UnityEngine.Purchasing.Security {
    public class AppleTangle
    {
        private static byte[] data = System.Convert.FromBase64String("fjSGBXI0CgIHURkLBQX7AAAHBgUrNIXHAgwvAgUBAQMGBjSFsh6FtwPoeT2Hj1ck1zzAtbueSw5v+y/4c3MqZXR0aGEqZ2tpK2V0dGhhZ2UAAhcGUVc1FzQVAgdRAA4XDkV0dDcyXjRmNQ80DQIHUQACFwZRVzUXG5XfGkNU7wHpWn2AKe8yplNIUejdMnvFg1Hdo529Nkb/3NF1mnqlVmhhJE1qZyo1IjQgAgdRAA8XGUV0OSJjJI43bvMJhsva76cr/VduX2ASNBACB1EABxcJRXR0aGEkVmtrcHBsa3ZtcH01EjQQAgdRAAcXCUV0XaMBDXgTRFIVGnDXs48nP0On0Wsg5u/Vs3TbC0HlI871aXzp47ETE6+ndZZDV1HFqytFt/z/53TJ4qdIJGtiJHBsYSRwbGFqJGV0dGhtZ2V2ZWdwbWdhJHdwZXBhaWFqcHcqNDE2NTA0NzJeEwk3MTQ2ND02NTA0AgdRGQoAEgAQL9RtQ5ByDfrwb4k0FQIHUQAOFw5FdHRoYSRNamcqNQxaNIYFFQIHURkkAIYFDDSGBQA0hgUEAg0ugkyC82dgAQU0hfY0LgKLd4Vkwh9fDSuWtvxATPRkPJoR8W1ibWdlcG1raiRFcXBsa3ZtcH01AjQLAgdRGRcFBfsAATQHBQX7NBkiNCACB1EADxcZRXR0aGEkR2F2cLMfuZdGIBYuwwsZskmYWmfMT4QTsT6p8AsKBJYPtSUSKnDROAnfZhIkR0U0hgUmNAkCDS6CTILzCQUFBSRlamAkZ2F2cG1ibWdlcG1raiR0QXobSG9UkkWNwHBmDxSHRYM3joU0hgC/NIYHp6QHBgUGBgUGNAkCDSgkZ2F2cG1ibWdlcGEkdGtobWd9xGc3c/M+AyhS794LJQrevncdS7HNHXbxWQrRe1uf9iEHvlGLSVkJ9WOLDLAk88+oKCRrdLI7BTSIs0fLhBAv1G1DkHIN+vBviSpEovNDSXtqYCRna2pgbXBta2p3JGtiJHF3YVZhaG1lamdhJGtqJHBsbXckZ2F2YDEnEU8RXRm3kPPymJrLVL7FXFR9JGV3d3FpYXckZWdnYXRwZWpnYTKdSCl8s+mIn9j3c5/2ctZzNEvFdGhhJFZra3AkR0U0GhMJNDI0MDas2HomMc4h0d0L0m/QpiAnFfOlqI8djdr9T2jxA68mNAbsHDr8VA3XCQINLoJMgvMJBQUBAQQHhgUFBFh0aGEkR2F2cG1ibWdlcG1raiRFcS6CTILzCQUFAQEENGY1DzQNAgdRkZp+CKBDj1/QEjM3z8ALScoQbdULmTn3L00sHsz6yrG9Ct1aGNLPORuBh4EfnTlDM/atn0SKKNC1lBbcTdxymzcQYaVzkM0pBgcFBAWnhgUqRKLzQ0l7DFo0GwIHURknABw0ErU0XOheADaIbLeLGdphd/tjWmG4cG1ibWdlcGEkZn0kZWp9JHRldnC68Hef6tZgC899SzDcpjr9fPtvzGZoYSR3cGVqYGV2YCRwYXZpdyRle0WsnP3VzmKYIG8V1Ke/4B8uxxsBBAeGBQsENIYFDgaGBQUE4JWtDQwvAgUBAQMGBRIabHBwdHc+KytzVK6O0d7g+NQNAzO0cXEl");
        private static int[] order = new int[] { 28,37,51,36,51,8,15,58,36,56,12,36,52,53,24,41,46,58,30,56,33,34,55,36,29,52,59,36,53,45,52,53,44,57,56,56,44,43,38,57,40,48,48,54,46,47,51,54,52,55,55,51,53,59,57,55,59,58,58,59,60 };
        private static int key = 4;

        public static readonly bool IsPopulated = true;

        public static byte[] Data() {
        	if (IsPopulated == false)
        		return null;
            return Obfuscator.DeObfuscate(data, order, key);
        }
    }
}
#endif
