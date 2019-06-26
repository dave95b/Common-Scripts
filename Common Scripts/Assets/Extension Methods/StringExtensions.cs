using UnityEngine;

public static class StringExtensions {

	public static bool EndsWithFast(this string a, string endWith) {
		int ap = a.Length - 1;
		int bp = endWith.Length - 1;

		while (ap >= 0 && bp >= 0 && a[ap] == endWith[bp]) {
			ap--;
			bp--;
		}

		return (bp < 0 && a.Length >= endWith.Length) || (ap < 0 && endWith.Length >= a.Length);
	}

	public static bool StartsWithFast(this string a, string startsWith) {
		int aLen = a.Length;
		int bLen = startsWith.Length;
		int ap = 0; 
		int bp = 0;

		while (ap < aLen && bp < bLen && a[ap] == startsWith[bp]) {
			ap++;
			bp++;
		}

		return (bp == bLen && aLen >= bLen) || (ap == aLen && bLen >= aLen);
	}
}
