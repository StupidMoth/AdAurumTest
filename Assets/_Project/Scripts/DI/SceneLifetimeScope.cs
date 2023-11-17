using UnityEngine;
using VContainer;
using VContainer.Unity;
using Infrastructure;
using Infrastructure.Serialization;
using Infrastructure.Resources;
using Game;
using Game.UI;

public class SceneLifetimeScope : LifetimeScope
{
    [SerializeField]
    private GameConfig _gameConfig;

    [SerializeField]
    private ScreensMediator _screensMediator;

    protected override void Configure(IContainerBuilder builder)
    {
        builder.RegisterEntryPoint<QuizRunner>();

        builder.RegisterInstance(_gameConfig);

        builder
            .RegisterInstance(_screensMediator)
            .As<IScreensMediator>();

        builder
            .Register<JsonLoader>(Lifetime.Singleton)
            .As<IDataLoader>();

        builder
            .Register<NewtonsoftJsonSerializer>(Lifetime.Singleton)
            .As<IJsonSerializer>();

        builder
            .Register<SpriteLoader>(Lifetime.Singleton)
            .As<ISpriteLoader>();

        builder
            .Register<QuizCounter>(Lifetime.Singleton)
            .As<IQuizCounter>();
    }
}
