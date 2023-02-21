using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

namespace DefaultNamespace {
	public static class Helpers {
		
		public static async UniTask<Texture2D>  DownloadImage(string url, CancellationToken ct = default) {
			if (string.IsNullOrEmpty(url)) 
				throw new ArgumentException(url);

			UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
			await www.SendWebRequest().ToUniTask(cancellationToken: ct);
			Texture2D loadedTexture = DownloadHandlerTexture.GetContent(www);
			return loadedTexture;
		}
		
		public static async UniTask<Sprite>  DownloadImageAsSprite(string url, CancellationToken ct = default) {
			var texture = await DownloadImage(url, ct);
			if (texture == null) return null;
			return Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height),
				new Vector2(0.5f,0.5f));
		}

	
	}
}